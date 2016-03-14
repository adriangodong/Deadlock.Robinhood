using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class Position
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("intraday_quantity")]
        public decimal IntradayQuantity { get; set; }

        [JsonProperty("shares_held_for_sells")]
        public decimal SharesHeldForSells { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("shares_held_for_buys")]
        public decimal SharesHeldForBuys { get; set; }

        [JsonProperty("average_buy_price")]
        public decimal AverageBuyPrice { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
    }
}
