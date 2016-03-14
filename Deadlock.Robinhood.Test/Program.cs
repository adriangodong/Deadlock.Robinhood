using System;
using System.Threading.Tasks;
using Deadlock.Robinhood;
using System.Text.RegularExpressions;

namespace Deadlock.Robinhood.Test
{
    class Program
    {
        static Config _config = null;
        static string _token = "";
        static string _account = "";
        static string _username = "";
        static string _password = "";
        static string _instrumentTwitter = "https://api.robinhood.com/instruments/3a47ca97-d5a2-4a55-9045-053a588894de/";
        static string _orderId = "";

        static void Main(string[] args)
        {
            _config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "config.personal.json"));
            _token = _config.Token;
            _account = _config.Account;
            _username = _config.Username;
            _password = _config.Password;
            Test().Wait();           
            Console.ReadLine();
        }

        static async Task Test()
        {
            //await Login();
            //await LoginWithToken();
            //await GetUserInformations();
            //await ListAccounts();
            //await ListPositions();
            //await GetPortfolios();
            //await ListOrders();
            //await NewOrder();
            //await CancelOrder();
            //await GetInstrument();
            //await GetQuote();
        }

        static async Task Login()
        {
            using (RobinhoodClient client = new RobinhoodClient())
            {
                var result = await client.Login(_username, _password);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(result.Data.Token);
                }
            }
        }

        static async Task LoginWithToken()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Quote("TWTR");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(result.Data.Symbol);
                }
            }
        }

        static async Task GetUserInformations()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.User();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(result.Data.Username);
                }
            }
        }

        static async Task ListAccounts()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Accounts();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Data.Results.ForEach(account =>
                        Console.WriteLine(account.AccountNumber)
                    );
                }
            }
        }

        static async Task ListPositions()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Positions();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Data.Results.ForEach(position =>
                        Console.WriteLine(position.Quantity)
                    );
                }
            }
        }

        static async Task GetPortfolios()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var resultPortfolios = await client.Portfolios();
                if (resultPortfolios.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    resultPortfolios.Data.Results.ForEach(portfolio =>
                        Console.WriteLine(portfolio.MarketValue)
                    );
                }

                //by accountNumber
                var resultPortfolio = await client.Portfolios(UrlManager.GetAccountNumber(_account));
                if (resultPortfolio.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(resultPortfolio.Data.MarketValue);
                }
            }
        }

        static async Task ListOrders()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Orders();
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Data.Results.ForEach(order =>
                        Console.WriteLine(order.Price)
                    );
                }
            }
        }

        static async Task NewOrder()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Orders(new Model.NewOrder()
                {
                    Account = _account,                 
                    Price = 10,
                    Quantity = 1,
                    Side = Model.Side.Buy,
                    TimeInForce = "gfd",
                    Trigger = "immediate",
                    Type = "market",
                    Symbol = "TWTR",
                    Instrument = _instrumentTwitter
                });
                if (result.IsSuccessStatusCode)
                {
                    _orderId = result.Data.Id;
                }
            }
        }

        static async Task CancelOrder()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.CancelOrder(_orderId);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {

                }
            }
        }

        static async Task GetInstrument()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Instrument(UrlManager.GetInstrumentNumber(_instrumentTwitter));
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(result.Data.Name);
                }
            }
        }

        static async Task GetQuote()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Quote("TWTR");
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(result.Data.BidPrice);
                }
            }
        }
    }
}
