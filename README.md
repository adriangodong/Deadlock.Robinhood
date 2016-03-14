# Deadlock.Robinhood (1.0.0.5)

Robinhood
Free stock trading.
Stop paying up to $10 for every trade.

C# Framework to make trades with the private [Robinhood](https://www.robinhood.com/) API. 
Using this API is not encouraged, since it's not officially available. 

> This framework was inspired by a deprecated Python framework originally developed by [@Rohanpai](https://github.com/rohanpai).

> Disclaimer: This is an unofficial client package.
I'm not affiliated with the folks at Robinhood Markets Inc.



## Features
      
* Login
* Get User
* Get Accounts
* Get Positions
* Get Portfolio
* Get Orders
* Get Instrument
* Get Quote


```c#

using Deadlock.Robinhood;

static string _token = "";
static string _account = "";
static string _username = "";
static string _password = "";
```

### Login with username and password

```c#

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
```

### Login with token

```c#

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
```

### Get user informations

```c#

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
```

### List Accounts

```c#

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
```

### List Positions

```c#

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
```

### Get Portfolio

```c#

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
```

### List Orders

```c#

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
```

### Get Instrument

```c#

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
```

### Get Quote

```c#

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
```