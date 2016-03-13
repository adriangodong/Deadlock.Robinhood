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

        [JsonProperty("cash")]
        public decimal Cash { get; set; }

        [JsonProperty("withdrawal_halted")]
        public bool WithdrawalHalted { get; set; }

        [JsonProperty("cash_available_for_withdrawal")]
        public decimal CashAvailableForWithdrawal { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }
    }
}
