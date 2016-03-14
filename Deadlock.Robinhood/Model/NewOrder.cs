using Deadlock.Robinhood.Converters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class NewOrder
    {
        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumToLowerConverter))]
        public Side Side { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("time_in_force")]
        public string TimeInForce { get; set; }

        [JsonProperty("trigger")]
        public string Trigger { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
