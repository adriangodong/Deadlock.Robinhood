using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class Order
    {
        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("executions")]
        public List<OrderExecution> Executions { get; set; }

        [JsonProperty("time_in_force")]
        public string TimeInForce { get; set; }

        [JsonProperty("fees")]
        public decimal Fees { get; set; }

        [JsonProperty("cancel")]
        public string Cancel { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cumulative_quantity")]
        public decimal CumulativeQuantity { get; set; }

        [JsonProperty("stop_price")]
        public string StopPrice { get; set; }

        [JsonProperty("reject_reason")]
        public string RejectReason { get; set; }

        [JsonProperty("instrument")]
        public string Instrument { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("trigger")]
        public string Trigger { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("last_transaction_at")]
        public DateTime LastTransactionAt { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("side")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Side Side { get; set; }

        [JsonProperty("average_price")]
        public decimal AveragePrice { get; set; }

        [JsonProperty("quantity")]
        public decimal Quantity { get; set; }
    }
}
