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
    public class RobinhoodClient : IDisposable
    {
        #region Fields
        private readonly string _endpoint_base = "https://api.robinhood.com/";

        private readonly string _endpoint_login = "api-token-auth/";

        private readonly string _endpoint_user = "user/";

        private readonly string _endpoint_accounts = "accounts/";

        private readonly string _endpoint_positions = "accounts/{0}/positions/";

        private readonly string _endpoint_portfolio = "accounts/{0}/portfolio/";

        private readonly string _endpoint_orders = "orders/";

        private readonly string _endpoint_instrument = "instruments/{0}/";

        private readonly string _endpoint_quote = "quotes/{0}/";

        private HttpClient _client;
        #endregion

        public RobinhoodClient(string token = null)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_endpoint_base);
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
            var result = await this.Request<Authentication>(_endpoint_login, Method.Post, new FormUrlEncodedContent(new Dictionary<string, string>()
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
            return await this.Request<User>(_endpoint_user);                     
        }

        //FALTA
        public async Task<Result<Page<Account>>> Accounts()
        {
            return await this.Request<Page<Account>>(_endpoint_accounts);            
        }
        
        public async Task<Result<Portfolio>> Portfolio(string accountNumber)
        {
            return await this.Request<Portfolio>(string.Format(_endpoint_portfolio, accountNumber));
        }

        public async Task<Result<Page<Order>>> Orders()
        {
            return await this.Request<Page<Order>>(_endpoint_orders);
        }

        public async Task<Result<Page<Position>>> Positions(string accountNumber)
        {
            return await this.Request<Page<Position>>(string.Format(_endpoint_positions, accountNumber));
        }

        public async Task<Result<Instrument>> Instrument(string instrument)
        {
            return await this.Request<Instrument>(string.Format(_endpoint_instrument, instrument));
        }

        public async Task<Result<Quote>> Quote(string symbol)
        {
            return await this.Request<Quote>(string.Format(_endpoint_quote, symbol));
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
                throw new System.Security.Authentication.AuthenticationException("Requires authentication");

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
                        response = await _client.PostAsync(_endpoint_login, content);
                        break;
                }

                result.StatusCode = response.StatusCode;
                if (response.IsSuccessStatusCode)
                { 
                    string data = await response.Content.ReadAsStringAsync();
                    result.Data = JsonConvert.DeserializeObject<T>(data, new JsonSerializerSettings() {
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
