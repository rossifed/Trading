namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal class FutureContractTick
    {
        internal Money TickSize { get; }

        internal Money TickValue { get; }


        internal FutureContractTick(Money tickSize, Money tickValue) { 
        this.TickValue = tickValue;
            this.TickSize = tickSize;
        }

        internal decimal PointValue => (TickValue / TickSize).Amount;
    }
}
