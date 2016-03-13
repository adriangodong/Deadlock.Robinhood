using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class Instrument
    {
        [JsonProperty("margin_initial_ratio")]
        public decimal MarginInitialRatio { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("bloomberg_unique")]
        public string BloombergUnique { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("tradeable")]
        public bool Tradeable { get; set; }

        [JsonProperty("maintenance_ratio")]
        public decimal MaintenanceRatio { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("splits")]
        public string Splits { get; set; }

        [JsonProperty("quote")]
        public string Quote { get; set; }

        [JsonProperty("fundamentals")]
        public string Fundamentals { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }
    }
}
