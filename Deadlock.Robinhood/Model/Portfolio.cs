using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class Portfolio
    {
        [JsonProperty("extended_hours_equity")]
        public decimal ExtendedHoursEquity { get; set; }

        [JsonProperty("adjusted_equity_previous_close")]
        public decimal AdjustedEquityPreviousClose { get; set; }

        [JsonProperty("last_core_market_value")]
        public decimal LastCoreMarketValue { get; set; }

        [JsonProperty("last_core_equity")]
        public decimal LastCoreEquity { get; set; }

        [JsonProperty("excess_margin")]
        public decimal ExcessMargin { get; set; }

        [JsonProperty("equity")]
        public decimal Equity { get; set; }

        [JsonProperty("market_value")]
        public decimal MarketValue { get; set; }

        [JsonProperty("equity_previous_close")]
        public decimal EquityPreviousClose { get; set; }

        [JsonProperty("extended_hours_market_value")]
        public decimal ExtendedHoursMarketValue { get; set; }

        //{
        //    "extended_hours_equity": "xxxxx",
        //    "url": "https:\/\/api.robinhood.com\/portfolios\/xxxxx\/",
        //    "adjusted_equity_previous_close": "xxxxx",
        //    "account": "https:\/\/api.robinhood.com\/accounts\/xxxxx\/",
        //    "last_core_market_value": "xxxxx",
        //    "last_core_equity": "xxxxx",
        //    "excess_margin": "xxxxx",
        //    "equity": "xxxxx",
        //    "market_value": "xxxxx",
        //    "equity_previous_close": "xxxxx",
        //    "extended_hours_market_value": "xxxxx"
        //}
    }
}
