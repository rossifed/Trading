using FluentDateTime;
namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal struct SettlementInfo
    {
        internal Currency SettlementCurrency { get; }
        internal int DaysToSettle { get; }
        public SettlementInfo(Currency settlementCurrency, int daysToSettle)
        {
            SettlementCurrency = settlementCurrency;
            DaysToSettle = daysToSettle;
        }

        internal DateOnly ComputeSettlementDate(DateOnly tradeDate)
        {
            return DateOnly.FromDateTime(tradeDate
                   .ToDateTime(TimeOnly.MinValue)
                   .AddBusinessDays(DaysToSettle));
        }

        public override string? ToString()
        {
            return $"{SettlementCurrency} {DaysToSettle}";
        }

        public override bool Equals(object? obj)
        {
            return obj is SettlementInfo info &&
                   EqualityComparer<Currency>.Default.Equals(SettlementCurrency, info.SettlementCurrency) &&
                   DaysToSettle == info.DaysToSettle;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(SettlementCurrency, DaysToSettle);
        }
    }
}
