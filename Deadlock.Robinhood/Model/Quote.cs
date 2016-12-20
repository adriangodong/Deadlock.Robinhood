using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class Quote
    {
        [JsonProperty("ask_price")]
        public decimal AskPrice { get; set; }

        [JsonProperty("ask_size")]
        public decimal AskSize { get; set; }

        [JsonProperty("bid_price")]
        public decimal BidPrice { get; set; }

        [JsonProperty("bid_size")]
        public decimal BidSize { get; set; }

        [JsonProperty("last_trade_price")]
        public decimal LastTradePrice { get; set; }

        [JsonProperty("last_extended_hours_trade_price")]
        public decimal LastExtendedHoursTradePrice { get; set; }

        [JsonProperty("previous_close")]
        public decimal PreviousClose { get; set; }

        [JsonProperty("adjusted_previous_close")]
        public decimal AdjustedPreviousClose { get; set; }

        [JsonProperty("previous_close_date")]
        public DateTime PreviousCloseDate { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("trading_halted")]
        public bool TradingHalted { get; set; }

        [JsonProperty("last_trade_price_source")]
        public string LastTradePriceSource { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; }
    }
}
