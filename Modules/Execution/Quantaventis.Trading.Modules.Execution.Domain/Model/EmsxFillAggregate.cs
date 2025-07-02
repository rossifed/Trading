namespace Quantaventis.Trading.Modules.Execution.Domain.Model
{
    internal class EmsxFillAggregate
    {

        internal string Symbol => YellowKey == "Equity" ? $"{Ticker} {Exchange} {YellowKey}" : $"{Ticker} {YellowKey}";
        internal IEnumerable<EmsxFill> EmsxFills { get; }

        internal int EmsxOrderId { get; }

        internal string? Account { get; set; }
        internal int OrderQuantity { get; }
        internal string? AssetClass { get; set; }
        internal int? BasketId { get; set; }
        internal string? BbgId { get; set; }
        internal string? BlockId { get; set; }
        internal string? Broker { get; set; }
        internal string? ClearingAccount { get; set; }
        internal string? ClearingFirm { get; set; }
        internal DateOnly? ContractExpDate { get; set; }
        internal string Currency { get; }
        internal string? Cusip { get; set; }

        internal string Exchange { get; }


        internal int FilledQuantity { get; }
        internal string? InvestorId { get; set; }
        internal bool IsCFD { get; }
        internal string? Isin { get; set; }
        //internal bool? IsLeg { get; set; }
        //internal string? LastCapacity { get; set; }
        //internal string? LastMarket { get; set; }
        internal decimal? LimitPrice { get; set; }
        //internal string? Liquidity { get; set; }
        internal string? LocalExchangeSymbol { get; set; }
        //internal string? LocateBroker { get; set; }
        //internal string? LocateId { get; set; }
        //internal bool? LocateRequired { get; set; }
        //internal string? MultiLegId { get; set; }
        //internal string? OccSymbol { get; set; }
        internal string? OrderExecutionInstruction { get; set; }
        internal string? OrderHandlingInstruction { get; set; }

        internal string? OrderInstruction { get; set; }
        internal string? OrderOrigin { get; set; }
        internal string? OrderReferenceId { get; set; }
        internal int? OriginatingTraderUUId { get; set; }



        internal string? SecurityName { get; set; }
        internal string? Sedol { get; set; }
        internal DateOnly? SettlementDate { get; set; }
        internal string Side { get; }
        internal decimal? StopPrice { get; set; }
        internal string? StrategyType { get; set; }
        internal string Ticker { get; }
        internal string? Tif { get; set; }
        internal string? TraderName { get; set; }
        internal int? TraderUUId { get; set; }
        internal string? OrderType { get; set; }
        internal decimal? UserCommissionAmount { get; set; }
        internal decimal? UserCommissionRate { get; set; }
        internal decimal? UserFees { get; set; }
        internal decimal? UserNetMoney { get; set; }
        internal string YellowKey { get; }

        internal int NumberOfFills { get; }
        public DateTime FirstFillDateTimeUtc { get; }
        public DateTime LastFillDateTimeUtc { get; }


        public decimal AvgPrice { get; private set; }
        public decimal MaxFillPrice { get; private set; }
        public decimal MinFillPrice { get; private set; }





        internal EmsxFillAggregate(IEnumerable<EmsxFill> fills)
        {

            EmsxFills = fills.Where(x => !x.IsDFD);
            EmsxOrderId = EmsxFills.Single(x => x.OrderId);
            YellowKey = EmsxFills.Single(x => x.YellowKey);
            Exchange = EmsxFills.Single(x => x.Exchange);
            Ticker = EmsxFills.Single(x => x.Ticker);
            EmsxOrderId = EmsxFills.Single(x => x.OrderId);
            YellowKey = EmsxFills.Single(x => x.YellowKey);
            Exchange = EmsxFills.Single(x => x.Exchange);
            Ticker = EmsxFills.Single(x => x.Ticker);
            Account = EmsxFills.Single(x => x.Account);
            Side = EmsxFills.Single(x => x.Side);
            OrderQuantity = Convert.ToInt32(EmsxFills.Single(x => x.Amount));
            AssetClass = EmsxFills.Single(x => x.AssetClass);
            BasketId = EmsxFills.Single(x => x.BasketId);
            Broker = EmsxFills.Single(x => x.Broker);
            BbgId = EmsxFills.Single(x => x.BbgId);
            ContractExpDate = EmsxFills.SingleOrDefault(x => x.ContractExpDate);
            Currency = EmsxFills.Single(x => x.Currency);
            ClearingFirm = EmsxFills.SingleOrDefault(x => x.ClearingFirm);
            ClearingAccount = EmsxFills.SingleOrDefault(x => x.ClearingAccount);
            Cusip = EmsxFills.SingleOrDefault(x => x.Cusip);
            Sedol = EmsxFills.SingleOrDefault(x => x.Sedol);
            Isin = EmsxFills.SingleOrDefault(x => x.Isin);
            FirstFillDateTimeUtc = EmsxFills.Min(x => x.DateTimeOfFillUtc);
            LastFillDateTimeUtc = EmsxFills.Max(x => x.DateTimeOfFillUtc);
            NumberOfFills = EmsxFills.Count();
            AvgPrice = EmsxFills.ComputeAveragePrice();
            MaxFillPrice = EmsxFills.Max(x => x.FillPrice);
            MinFillPrice = EmsxFills.Min(x => x.FillPrice);
            FilledQuantity = EmsxFills.Sum(x => x.FillShares);

            IsCFD = EmsxFills.Single(x => x.IsCFD);
            LimitPrice = EmsxFills.SingleOrDefault(x => x.LimitPrice);
            StopPrice = EmsxFills.SingleOrDefault(x => x.StopPrice);
            LocalExchangeSymbol = EmsxFills.SingleOrDefault(x => x.LocalExchangeSymbol);
            OrderExecutionInstruction = EmsxFills.SingleOrDefault(x => x.OrderExecutionInstruction);
            OrderHandlingInstruction = EmsxFills.SingleOrDefault(x => x.OrderHandlingInstruction);
            OrderInstruction = EmsxFills.SingleOrDefault(x => x.OrderInstruction);
            OrderOrigin = EmsxFills.SingleOrDefault(x => x.OrderOrigin);
            OrderReferenceId = EmsxFills.SingleOrDefault(x => x.OrderReferenceId);

            SecurityName = EmsxFills.Single(x => x.SecurityName);
            SettlementDate = EmsxFills.SingleOrDefault(x => x.SettlementDate);
            StrategyType = EmsxFills.Single(x => x.StrategyType);
            Tif = EmsxFills.Single(x => x.Tif);
            TraderName = EmsxFills.Single(x => x.TraderName);
            TraderUUId = EmsxFills.Single(x => x.TraderUUId);
            OrderType = EmsxFills.Single(x => x.OrderType);
            UserCommissionAmount = EmsxFills.Sum(x => x.UserCommissionAmount);
            UserCommissionRate = EmsxFills.Average(x => x.UserCommissionRate);
            UserFees = EmsxFills.Sum(x => x.UserFees);
            UserNetMoney = EmsxFills.Sum(x => x.UserNetMoney);
        }

        public override string? ToString()
        {
            return $"{Side} {FilledQuantity} {Symbol} EmsxOrderId:{EmsxOrderId}";
        }

        public override bool Equals(object? obj)
        {
            return obj is EmsxFillAggregate aggregate &&
                   EmsxOrderId == aggregate.EmsxOrderId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(EmsxOrderId);
        }
    }
}
