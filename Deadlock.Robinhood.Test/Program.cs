using System;
using System.Threading.Tasks;
using Deadlock.Robinhood;

namespace Deadlock.Robinhood.Test
{
    class Program
    {
        static Config _config = null;
        static string _token = "";
        static string _account = "";
        static string _username = "";
        static string _password = "";

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
            await Login();
            await LoginWithToken();
            await GetUserInformations();
            await ListAccounts();
            await ListPositions();
            await GetPortfolio();
            await ListOrders();
            await GetInstrument();
            await GetQuote();
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
                var result = await client.Positions(_account);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    result.Data.Results.ForEach(position =>
                        Console.WriteLine(position.Quantity)
                    );
                }
            }
        }

        static async Task GetPortfolio()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Portfolio(_account);
                if (result.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine(result.Data.MarketValue);
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

        static async Task GetInstrument()
        {
            using (RobinhoodClient client = new RobinhoodClient(_token))
            {
                var result = await client.Instrument("3a47ca97-d5a2-4a55-9045-053a588894de"); //twitter
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
