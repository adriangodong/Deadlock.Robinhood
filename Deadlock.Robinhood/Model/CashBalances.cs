using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class CashBalances
    {

        [JsonProperty("cash_held_for_orders")]
        public decimal CashHeldForOrders { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("cash")]
        public decimal Cash { get; set; }

        [JsonProperty("buying_power")]
        public decimal BuyingPower { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("cash_available_for_withdrawal")]
        public decimal CashAvailableForWithdrawal { get; set; }

        [JsonProperty("uncleared_deposits")]
        public decimal UnclearedDeposits { get; set; }

        [JsonProperty("unsettled_funds")]
        public decimal UnsettledFunds { get; set; }

    }
}
