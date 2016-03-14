using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Deadlock.Robinhood
{
    public static class UrlManager
    {
        public static string Base { get; } = "https://api.robinhood.com/";

        public static string Login { get; } = "api-token-auth/";

        public static string User { get; } = "user/";

        public static string Accounts { get; } = "accounts/";

        public static string Portfolios() => "portfolios/";

        public static string Portfolios(string accountNumber) => $"accounts/{accountNumber}/portfolio/";

        public static string Orders { get; } = "orders/";

        public static string CancelOrder(string orderNumber) => $"orders/{orderNumber}/cancel/";

        public static string Positions() => "positions/";

        public static string Positions(string accountNumber) => $"accounts/{accountNumber}/positions/";

        public static string Instrument(string instrumentNumber) => $"instruments/{instrumentNumber}/";

        public static string Quotes(string symbol) => $"quotes/{symbol}/";

        public static string GetAccountNumber(string account) => Regex.Match(account, "^.*/(.*)/$").Groups[1].Value;

        public static string GetInstrumentNumber(string instrument) => Regex.Match(instrument, "^.*/(.*)/$").Groups[1].Value;
    }
}
