using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class Account
    {
        [JsonProperty("deactivated")]
        public bool Deactivated { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("margin_balances")]
        public MarginBalances MarginBalances { get; set; }

        [JsonProperty("cash_balances")]
        public CashBalances CashBalances { get; set; }

        [JsonProperty("withdrawal_halted")]
        public bool WithdrawalHalted { get; set; }

        [JsonProperty("cash_available_for_withdrawal")]
        public decimal CashAvailableForWithdrawal { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("max_ach_early_access_amount")]
        public decimal MaxAchEarlyAccessAmount { get; set; }

        [JsonProperty("cash_held_for_orders")]
        public decimal CashHeldForOrders { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("cash")]
        public decimal Cash { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("uncleared_deposits")]
        public decimal UnclearedDeposits { get; set; }

        [JsonProperty("unsettled_funds")]
        public decimal UnsettledFunds { get; set; }
    }
}
