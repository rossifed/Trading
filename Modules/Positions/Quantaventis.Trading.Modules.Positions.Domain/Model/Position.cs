using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Domain.Model
{
    internal class Position
    {
        internal byte PortfolioId { get; }
        internal int Quantity { get; }
        internal decimal NominalQuantity { get; }
        internal int InstrumentId => InvestedInstrument.InstrumentId;
        internal Currency LocalCurrency { get; }
        internal Currency BaseCurrency { get; }
        internal Money GrossEntryPriceLocal { get; }
        internal Money GrossEntryPriceBase { get; }

        internal Money NetEntryPriceLocal { get; }
        internal Money NetEntryPriceBase { get; }
        internal Money GrossTradeValueLocal { get; }
        internal Money GrossTradeValueBase { get; }
        internal Money NetTradeValueLocal { get; }
        internal Money NetTradeValueBase { get; }


        internal Money GrossNotionalValueLocal { get; }
        internal Money GrossNotionalValueBase { get; }
        internal Money NetNotionalValueLocal { get; }
        internal Money NetNotionalValueBase { get; }

        internal Money TotalCommissionLocal { get; }

        internal Money TotalCommissionBase { get; }


        internal bool IsSwap => InvestedInstrument.IsSwap;

        internal DateOnly PositionDate { get; }
        internal DateOnly FirstTradeDate { get; }

        internal DateOnly LastTradeDate { get; }
        internal InvestedInstrument InvestedInstrument { get; }
        internal Position(IEnumerable<TradeAllocation> tradeAllocations)
        {
            this.PortfolioId = tradeAllocations.Select(x => x.PortfolioId).Distinct().Single();

            this.InvestedInstrument = tradeAllocations.Select(x => x.InvestedInstrument).Distinct().Single();

            this.Quantity = tradeAllocations.Sum(x => x.Quantity);
            this.NominalQuantity = tradeAllocations.Sum(x => x.NominalQuantity);
            this.LocalCurrency = tradeAllocations.Select(x => x.LocalCurrency).Distinct().Single();
            this.BaseCurrency = tradeAllocations.Select(x => x.BaseCurrency).Distinct().Single();
            this.GrossTradeValueLocal = new Money(tradeAllocations.Sum(x => x.GrossTradeValueLocal.Amount), LocalCurrency);
            this.NetTradeValueLocal = new Money(tradeAllocations.Sum(x => x.NetTradeValueLocal.Amount), LocalCurrency);
            this.GrossTradeValueBase = new Money(tradeAllocations.Sum(x => x.GrossTradeValueBase.Amount), BaseCurrency);
            this.NetTradeValueBase = new Money(tradeAllocations.Sum(x => x.NetTradeValueBase.Amount), BaseCurrency);

            this.GrossNotionalValueLocal = new Money(tradeAllocations.Sum(x => x.GrossPrincipalLocal.Amount), LocalCurrency);
            this.NetNotionalValueLocal = new Money(tradeAllocations.Sum(x => x.NetPrincipalLocal.Amount), LocalCurrency);
            this.GrossNotionalValueBase = new Money(tradeAllocations.Sum(x => x.GrossPrincipalBase.Amount), BaseCurrency);
            this.NetNotionalValueBase = new Money(tradeAllocations.Sum(x => x.NetPrincipalBase.Amount), BaseCurrency);

            this.GrossEntryPriceLocal = Quantity != 0 ? GrossTradeValueLocal / Quantity : Money.Zero(LocalCurrency);
            this.GrossEntryPriceBase = Quantity != 0 ? GrossTradeValueBase / Quantity : Money.Zero(BaseCurrency);
            this.NetEntryPriceLocal = Quantity != 0 ? NetTradeValueLocal / Quantity : Money.Zero(LocalCurrency);
            this.NetEntryPriceBase = Quantity != 0 ? NetTradeValueBase / Quantity : Money.Zero(BaseCurrency);
            this.LastTradeDate = tradeAllocations.Max(x => x.TradeDate);
            this.FirstTradeDate = tradeAllocations.Min(x => x.TradeDate);
            this.TotalCommissionLocal = new Money(tradeAllocations.Sum(x => x.CommissionAmountLocal.Amount), LocalCurrency);
            this.TotalCommissionBase = new Money(tradeAllocations.Sum(x => x.CommissionAmountBase.Amount), BaseCurrency);
            this.PositionDate = LastTradeDate;
        }




        internal void Validate(TradeAllocation tradeAllocation)
        {
            if (!tradeAllocation.PortfolioId.Equals(PortfolioId))
                throw new InvalidOperationException($"TradeAllocation PortfolioId:{tradeAllocation.PortfolioId} is different than the Position PortfolioId:{PortfolioId}. TradeAllocationId:{tradeAllocation.Id}");
            if (!tradeAllocation.InvestedInstrument.Equals(InvestedInstrument))
                throw new InvalidOperationException($"TradeAllocation InvestedInstrument:{tradeAllocation.InvestedInstrument} is different than the Position InvestedInstrument:{InvestedInstrument}. TradeAllocationId:{tradeAllocation.Id}");
            if (!tradeAllocation.LocalCurrency.Equals(LocalCurrency))
                throw new InvalidOperationException($"TradeAllocation LocalCurrency:{tradeAllocation.LocalCurrency} is different than the Position LocalCurrency:{LocalCurrency}. TradeAllocationId:{tradeAllocation.Id}");
            if (!tradeAllocation.BaseCurrency.Equals(BaseCurrency))
                throw new InvalidOperationException($"TradeAllocation BaseCurrency:{tradeAllocation.BaseCurrency} is different than the Position BaseCurrency:{BaseCurrency}. TradeAllocationId:{tradeAllocation.Id}");

        }


        internal Position CopyAsOf(DateOnly asOfDate)
        {

            return new Position(PortfolioId,
        InvestedInstrument,
        asOfDate,
        Quantity,
        NominalQuantity,
        LocalCurrency,
         BaseCurrency,
         GrossEntryPriceLocal,
         GrossEntryPriceBase,
         NetEntryPriceLocal,
         NetEntryPriceBase,
         GrossTradeValueLocal,
         GrossTradeValueBase,
         NetTradeValueLocal,
         NetTradeValueBase,
         GrossNotionalValueLocal,
         GrossNotionalValueBase,
         NetNotionalValueLocal,
         NetNotionalValueBase,
         TotalCommissionLocal,
         TotalCommissionBase,
         FirstTradeDate,
         LastTradeDate
                );
        }

        internal Position Add(TradeAllocation tradeAllocation)
        {
            Validate(tradeAllocation);
            int newQuantity = Quantity + tradeAllocation.Quantity;
            decimal newNominalQuantity = NominalQuantity + tradeAllocation.NominalQuantity;
            Money newGrossTotalCostLocal = GrossTradeValueLocal + tradeAllocation.GrossTradeValueLocal;
            Money newNetTotalCostLocal = NetTradeValueLocal + tradeAllocation.NetTradeValueLocal;
            Money newGrossTotalCostBase = GrossTradeValueBase + tradeAllocation.GrossTradeValueBase;
            Money newNetTotalCostBase = NetTradeValueBase + tradeAllocation.NetTradeValueBase;

            Money newGrossEntryPriceLocal = newQuantity != 0 ? newGrossTotalCostLocal / newQuantity : Money.Zero(LocalCurrency);
            Money newGrossEntryPriceBase = newQuantity != 0 ? newGrossTotalCostBase / newQuantity : Money.Zero(BaseCurrency);
            Money newNetEntryPriceLocal = newQuantity != 0 ? newNetTotalCostLocal / newQuantity : Money.Zero(LocalCurrency);
            Money newNetEntryPriceBase = newQuantity != 0 ? newNetTotalCostBase / newQuantity : Money.Zero(BaseCurrency);

            return new Position(PortfolioId,

        InvestedInstrument,
        tradeAllocation.TradeDate,
        newQuantity,
        newNominalQuantity,
        LocalCurrency,
         BaseCurrency,
         newGrossEntryPriceLocal,
         newGrossEntryPriceBase,
         newNetEntryPriceLocal,
         newNetEntryPriceBase,
         newGrossTotalCostLocal,
         newGrossTotalCostBase,
         newNetTotalCostLocal,
         newNetTotalCostBase,
         GrossNotionalValueLocal + tradeAllocation.GrossPrincipalLocal,
         GrossNotionalValueBase + tradeAllocation.GrossPrincipalBase,
         NetNotionalValueLocal + tradeAllocation.NetPrincipalLocal,
         NetNotionalValueBase + tradeAllocation.NetPrincipalBase,
         TotalCommissionLocal + tradeAllocation.CommissionAmountLocal,
         TotalCommissionBase + tradeAllocation.CommissionAmountBase,
         FirstTradeDate,
         tradeAllocation.TradeDate

                );
        }

        public Position(
        byte portfolioId,
        InvestedInstrument investedInstrument,
        DateOnly positionDate,
        int quantity,
        decimal nominalQuantity,
        Currency localCurrency,
        Currency baseCurrency,
        decimal grossEntryPriceLocal,
        decimal grossEntryPriceBase,
        decimal netEntryPriceLocal,
        decimal netEntryPriceBase,
        decimal grossTotalCostLocal,
        decimal grossTotalCostBase,
        decimal netTotalCostLocal,
        decimal netTotalCostBase,
        decimal grossPrincipalLocal,
        decimal grossPrincipalBase,
        decimal netPrincipalLocal,
        decimal netPrincipalBase,
        decimal totalCommissionLocal,
        decimal totalCommissionBase,
        DateOnly firstTradeDate,
        DateOnly lastTradeDate
           ) : this(portfolioId,
         investedInstrument,
         positionDate,
         quantity,
         nominalQuantity,
         localCurrency,
         baseCurrency,
         new Money(grossEntryPriceLocal, localCurrency),
        new Money(grossEntryPriceBase, baseCurrency),
        new Money(netEntryPriceLocal, localCurrency),
         new Money(netEntryPriceBase, baseCurrency),
         new Money(grossTotalCostLocal, localCurrency),
         new Money(grossTotalCostBase, baseCurrency),
         new Money(netTotalCostLocal, localCurrency),
         new Money(netTotalCostBase, baseCurrency),
         new Money(grossPrincipalLocal, localCurrency),
         new Money(grossPrincipalBase, baseCurrency),
         new Money(netPrincipalLocal, localCurrency),
         new Money(netPrincipalBase, baseCurrency),
         new Money(totalCommissionLocal, localCurrency),
         new Money(totalCommissionBase, baseCurrency),
         firstTradeDate,
         lastTradeDate

               )
        {
        }
        public Position(
         byte portfolioId,

         InvestedInstrument investedInstrument,
           DateOnly positionDate,
         int quantity,
         decimal nominalQuantity,
         Currency localCurrency,
         Currency baseCurrency,
         Money grossEntryPriceLocal,
         Money grossEntryPriceBase,
         Money netEntryPriceLocal,
         Money netEntryPriceBase,
         Money grossTotalCostLocal,
         Money grossTotalCostBase,
         Money netTotalCostLocal,
         Money netTotalCostBase,
         Money grossPrincipalLocal,
         Money grossPrincipalBase,
         Money netPrincipalLocal,
         Money netPrincipalBase,
         Money totalCommissionLocal,
         Money totalCommissionBase,
         DateOnly firstTradeDate,
         DateOnly lastTradeDate
            )
        {
            this.PortfolioId = portfolioId;
            this.InvestedInstrument = investedInstrument;
            this.PositionDate = positionDate;
            this.Quantity = quantity;
            this.NominalQuantity = nominalQuantity;
            this.LocalCurrency = localCurrency;
            this.BaseCurrency = baseCurrency;
            this.GrossTradeValueLocal = grossTotalCostLocal;
            this.NetTradeValueLocal = netTotalCostLocal;
            this.GrossTradeValueBase = grossTotalCostBase;
            this.NetTradeValueBase = netTotalCostBase;

            this.GrossNotionalValueLocal = grossPrincipalLocal;
            this.NetNotionalValueLocal = netPrincipalLocal;
            this.GrossNotionalValueBase = grossPrincipalBase;
            this.NetNotionalValueBase = netPrincipalBase;

            this.GrossEntryPriceLocal = grossEntryPriceLocal;
            this.GrossEntryPriceBase = grossEntryPriceBase;
            this.NetEntryPriceLocal = netEntryPriceLocal;
            this.NetEntryPriceBase = netEntryPriceBase;
            this.LastTradeDate = lastTradeDate;
            this.FirstTradeDate = firstTradeDate;
            this.TotalCommissionLocal = totalCommissionLocal;
            this.TotalCommissionBase = totalCommissionBase;
        }




        internal static Position Create(TradeAllocation tradeAllocation)
                => Create(new List<TradeAllocation>() { tradeAllocation });


        internal static Position Create(IEnumerable<TradeAllocation> tradeAllocations)
            => new Position(tradeAllocations);


        internal bool IsFlat => Quantity == 0;

    }
}
