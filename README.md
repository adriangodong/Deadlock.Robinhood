# Deadlock.Robinhood (1.0.0.0)

      Robinhood
      Free stock trading.
      Stop paying up to $10 for every trade.
      Robinhood Client is the way you manage your account via api with C#.
      
      (*) Release 1.0.0.0
      - Login
      - Get User
      - Get Accounts
      - Get Positions
      - Get Portfolio
      - Get Orders
      - Get Instrument
      - Get Quote

using Deadlock.Robinhood;

public class Example
{

    
    static string _token = "";
    static string _account = "";
    static string _username = "";
    static string _password = "";

//Login with username and password

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

//Login with token

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

//Get user informations

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

//List Accounts

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

//List Positions

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

//Get Portfolio

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

//List Orders

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

//Get Instrument

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

//Get Quote

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
