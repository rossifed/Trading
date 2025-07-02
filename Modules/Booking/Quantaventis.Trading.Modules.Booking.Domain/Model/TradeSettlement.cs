namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class TradeSettlement
    {
        internal Currency SettlementCurrency { get; }
        internal DateOnly SettlementeDate { get; }
        public TradeSettlement(Currency settlementCurrency, DateTime settlementeDate)
       : this(settlementCurrency, DateOnly.FromDateTime(settlementeDate)) { }
        public TradeSettlement(Currency settlementCurrency, DateOnly settlementeDate)
        {
            SettlementCurrency = settlementCurrency;
            SettlementeDate = settlementeDate;
        }

        public override string? ToString()
        {
            return $"{SettlementCurrency} {SettlementeDate.ToString("yyyyMMdd")}";
        }
    }
}
