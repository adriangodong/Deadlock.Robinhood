using System;
using System.Threading.Tasks;
using Deadlock.Robinhood.Model;

namespace Deadlock.Robinhood
{
    public interface IRobinhoodClient : IDisposable
    {
        bool Authenticated { get; }
        string Token { get; }
        Task<Result<Authentication>> Login(string username, string password);
        Task<Result<User>> User();
        Task<Result<Page<Account>>> Accounts();
        Task<Result<Page<Portfolio>>> Portfolios();
        Task<Result<Portfolio>> Portfolios(string accountNumber);
        Task<Result<Page<Order>>> Orders();
        Task<Result<Page<Order>>> NextOrders(Page<Order> orders);
        Task<Result<Order>> Orders(NewOrder newOrder);
        Task<Result<object>> CancelOrder(string orderNumber);
        Task<Result<Page<Position>>> Positions();
        Task<Result<Page<Position>>> Positions(string accountNumber);
        Task<Result<Instrument>> Instrument(string instrumentNumber);
        Task<Result<Quote>> Quote(string symbol);
    }
}