using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Deadlock.Robinhood.Model;
using Newtonsoft.Json;

namespace Deadlock.Robinhood
{
    /// <summary>
    /// Inspirado em https://github.com/aurbano/robinhood-node
    /// </summary>
    public class RobinhoodClient : IRobinhoodClient, IDisposable
    {
        #region Fields
        private HttpClient _client;
        #endregion

        public RobinhoodClient(string token = null)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(UrlManager.Base);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Add("Accept", "*/*");
            //_client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate");
            _client.DefaultRequestHeaders.Add("Accept-Language", "en;q=1, fr;q=0.9, de;q=0.8, ja;q=0.7, nl;q=0.6, it;q=0.5");
            _client.DefaultRequestHeaders.Add("X-Robinhood-API-Version", "1.0.0");
            _client.DefaultRequestHeaders.Connection.Add("keep-alive");
            _client.DefaultRequestHeaders.Add("User-Agent", "Robinhood/823 (iPhone; iOS 7.1.2; Scale/2.00)");

            if (!string.IsNullOrEmpty(token))
                this.SetToken(token);
        }

        #region Properties
        public bool  Authenticated { get; private set; }   
        
        public string Token { get; private set; }
        #endregion

        #region Methods Public
        public async Task<Result<Authentication>> Login(string username, string password)
        {
            var result = await this.Request<Authentication>(UrlManager.Login, Method.Post, new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                { "password", password },
                { "username", username }
            }), false);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
                this.SetToken(result.Data.Token);            
            return result;
        }

        public async Task<Result<User>> User()
        {
            return await this.Request<User>(UrlManager.User);                     
        }

        //FALTA
        public async Task<Result<Page<Account>>> Accounts()
        {
            return await this.Request<Page<Account>>(UrlManager.Accounts);            
        }

        #region Methods Portfolios
        public async Task<Result<Page<Portfolio>>> Portfolios()
        {
            return await this.Request<Page<Portfolio>>(UrlManager.Portfolios());
        }

        public async Task<Result<Portfolio>> Portfolios(string accountNumber)
        {
            return await this.Request<Portfolio>(UrlManager.Portfolios(accountNumber));
        }
        #endregion

        #region Methods Orders
        public async Task<Result<Page<Order>>> Orders()
        {
            return await this.Request<Page<Order>>(UrlManager.Orders);
        }        

        public async Task<Result<Page<Order>>> NextOrders(Page<Order> orders)
        {
            if (orders.Next == null) {
                return null;
            }
            
            return await this.Request<Page<Order>>(orders.Next);
        }

        public async Task<Result<Order>> Orders(NewOrder newOrder)
        {
            var content = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(newOrder));           
            var formContent = new FormUrlEncodedContent(content);
            return await this.Request<Order>(UrlManager.Orders, Method.Post, formContent);
        }

        public async Task<Result<object>> CancelOrder(string orderNumber)
        {
            return await this.Request<object>(UrlManager.CancelOrder(orderNumber), Method.Post);
        }
        #endregion

        #region Methods Positions
        public async Task<Result<Page<Position>>> Positions()
        {
            return await this.Request<Page<Position>>(UrlManager.Positions());
        }

        public async Task<Result<Page<Position>>> Positions(string accountNumber)
        {
            return await this.Request<Page<Position>>(UrlManager.Positions(accountNumber));
        }
        #endregion

        public async Task<Result<Instrument>> Instrument(string instrumentNumber)
        {
            return await this.Request<Instrument>(UrlManager.Instrument(instrumentNumber));
        }

        public async Task<Result<Quote>> Quote(string symbol)
        {
            return await this.Request<Quote>(UrlManager.Quotes(symbol.ToUpper()));
        }

        public void Dispose()
        {
            _client.Dispose();
        }
        #endregion

        #region Methods Private
        private void SetToken(string token)
        {
            this.Authenticated = true;
            this.Token = token;
            _client.DefaultRequestHeaders.Add("Authorization", $"Token {token}");
        }

        private async Task<Result<T>> Request<T>(string endpoint, Method method = Method.Get, HttpContent content = null, bool needAuthentication = true)
        {
            if (needAuthentication && !this.Authenticated)
                throw new InvalidOperationException("Requires authentication");

            Result<T> result = Activator.CreateInstance<Result<T>>();
            try
            {              
                HttpResponseMessage response = null;
                switch(method)
                {
                    case Method.Get:                        
                        response = await _client.GetAsync(endpoint);
                        break;
                    case Method.Post:
                        response = await _client.PostAsync(endpoint, content);
                        break;
                }

                result.IsSuccessStatusCode = response.IsSuccessStatusCode;
                result.StatusCode = response.StatusCode;
                result.Content = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {                     
                    result.Data = JsonConvert.DeserializeObject<T>(result.Content, new JsonSerializerSettings() {
                        NullValueHandling = NullValueHandling.Ignore
                    });
                }
            }
            catch(Exception ex)
            {

            }
            return result;
        }
        #endregion
    }
}
