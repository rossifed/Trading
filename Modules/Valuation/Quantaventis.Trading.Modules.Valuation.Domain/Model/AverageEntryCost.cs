namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class AverageEntryCost
    {
        internal Money AverageEntryPrice { get; }
        internal FxRate AverageEntryFxRate { get; }

        internal Money AverageEntryPriceLocal { get; }

        public AverageEntryCost(Money averageEntryPriceLocal, FxRate averageEntryFxRate)
        {
            AverageEntryPriceLocal = averageEntryPriceLocal;
            AverageEntryFxRate = averageEntryFxRate; 
            AverageEntryPrice = AverageEntryPriceLocal * averageEntryFxRate;
        }
    }
}
