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
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

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
    }
}
