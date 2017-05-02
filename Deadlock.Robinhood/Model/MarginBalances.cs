using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class MarginBalances
    {

        [JsonProperty("day_trade_buying_power")]
        public decimal DayTradeBuyingPower { get; set; }

        [JsonProperty("start_of_day_overnight_buying_power")]
        public decimal StartOfDayOvernightBuyingPower { get; set; }

        [JsonProperty("overnight_buying_power_held_for_orders")]
        public decimal OvernightBuyingPowerHeldForOrders { get; set; }

        [JsonProperty("cash_held_for_orders")]
        public decimal CashHeldForOrders { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("start_of_day_dtbp")]
        public decimal StartOfDayDtbp { get; set; }

        [JsonProperty("day_trade_buying_power_held_for_orders")]
        public decimal DayTradeBuyingPowerHeldForOrders { get; set; }

        [JsonProperty("overnight_buying_power")]
        public decimal OvernightBuyingPower { get; set; }

        [JsonProperty("marked_pattern_day_trader_datecash")]
        public DateTime? MarkedPatternDayTraderDate { get; set; }

        [JsonProperty("cash")]
        public decimal Cash { get; set; }

        [JsonProperty("unallocated_margin_cash")]
        public decimal UnallocatedMarginCash { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("cash_available_for_withdrawal")]
        public decimal CashAvailableForWithdrawal { get; set; }

        [JsonProperty("margin_limit")]
        public decimal MarginLimit { get; set; }

        [JsonProperty("outstanding_interest")]
        public decimal OutstandingInterest { get; set; }

        [JsonProperty("uncleared_deposits")]
        public decimal UnclearedDeposits { get; set; }

        [JsonProperty("unsettled_funds")]
        public decimal UnsettledFunds { get; set; }

        [JsonProperty("day_trade_ratio")]
        public decimal DayTradeRatio { get; set; }

        [JsonProperty("overnight_ratio")]
        public decimal OvernightRatio { get; set; }

    }
}
