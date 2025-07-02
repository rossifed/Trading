namespace Quantaventis.Trading.Modules.Booking.Api.Dto
{
    public class EmsxTradeDto
    {
        public string Symbol { get; set; }


        public int EmsxOrderId { get; set; }

        public string? Account { get; set; }
        public int OrderQuantity { get; set; }
        public string? AssetClass { get; set; }
        public int? BasketId { get; set; }
        public string? BbgId { get; set; }
        public string? BlockId { get; set; }
        public string? Broker { get; set; }
        public string? ClearingAccount { get; set; }
        public string? ClearingFirm { get; set; }
        public DateOnly? ContractExpDate { get; set; }

        public string Currency { get; set; }
        public string? Cusip { get; set; }

        public string Exchange { get; set; }

        public string? ExecType { get; set; }
        public string? ExecutingBroker { get; set; }

        public int FilledQuantity { get; set; }

        public bool IsCFD { get; set; }
        public string? Isin { get; set; }

        public decimal? LimitPrice { get; set; }

        public string? LocalExchangeSymbol { get; set; }


        public string? OrderExecutionInstruction { get; set; }
        public string? OrderHandlingInstruction { get; set; }

        public string? OrderInstruction { get; set; }
        public string? OrderOrigin { get; set; }
        public string? OrderReferenceId { get; set; }
        public int? OriginatingTraderUUId { get; set; }



        public string? SecurityName { get; set; }
        public string? Sedol { get; set; }
        public DateOnly? SettlementDate { get; set; }
        public string Side { get; set; }
        public decimal? StopPrice { get; set; }
        public string? StrategyType { get; set; }
        public string Ticker { get; set; }
        public string? Tif { get; set; }
        public string? TraderName { get; set; }
        public int? TraderUUId { get; set; }
        public string? OrderType { get; set; }
        public decimal? UserCommissionAmount { get; set; }
        public decimal? UserCommissionRate { get; set; }
        public decimal? UserFees { get; set; }
        public decimal? UserNetMoney { get; set; }
        public string YellowKey { get; set; }
        public byte NumberOfFills { get; set; }
        public DateTime FirstFillDateTimeUtc { get; set; }
        public DateTime LastFillDateTimeUtc { get; set; }

        public decimal AvgPrice { get; set; }
        public decimal MaxFillPrice { get; set; }
        public decimal MinFillPrice { get; set; }

    }
}
