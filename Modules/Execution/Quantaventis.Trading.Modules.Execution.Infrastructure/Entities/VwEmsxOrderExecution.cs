using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;

public partial class VwEmsxOrderExecution
{
    public string? Symbol { get; set; }

    public string? Account { get; set; }

    public int? OrderQuantity { get; set; }

    public decimal ContractMultiplier { get; set; }

    public decimal? GrossMarketValue { get; set; }

    public decimal? GrossNotionalAmount { get; set; }

    public string? AssetClass { get; set; }

    public int? BasketId { get; set; }

    public string? Bbgid { get; set; }

    public string? BlockId { get; set; }

    public string? Broker { get; set; }

    public string? ClearingAccount { get; set; }

    public string? ClearingFirm { get; set; }

    public DateTime? ContractExpDate { get; set; }

    public string? Currency { get; set; }

    public int? InstrumentId { get; set; }

    public string? InstrumentType { get; set; }

    public string? Cusip { get; set; }

    public DateTime? TradeDate { get; set; }

    public DateTime? FirstFillTime { get; set; }

    public DateTime? LastFillTime { get; set; }

    public string? Exchange { get; set; }

    public string? ExecutingBroker { get; set; }

    public decimal? AvgPrice { get; set; }

    public decimal? MaxFillPrice { get; set; }

    public decimal? MinFillPrice { get; set; }

    public int? FilledQuantity { get; set; }

    public bool? IsCfd { get; set; }

    public string? Isin { get; set; }

    public decimal? LimitPrice { get; set; }

    public string? LocalExchangeSymbol { get; set; }

    public string? OrderExecutionInstruction { get; set; }

    public string? OrderHandlingInstruction { get; set; }

    public int OrderId { get; set; }

    public string? OrderInstruction { get; set; }

    public string? OrderOrigin { get; set; }

    public string? OrderReferenceId { get; set; }

    public int? OriginatingTraderUuid { get; set; }

    public string? SecurityName { get; set; }

    public string? Sedol { get; set; }

    public DateTime? SettlementDate { get; set; }

    public string? Side { get; set; }

    public decimal? StopPrice { get; set; }

    public string? StrategyType { get; set; }

    public string? Ticker { get; set; }

    public string? Tif { get; set; }

    public string? TraderName { get; set; }

    public int? TraderUuid { get; set; }

    public string? Type { get; set; }

    public decimal? UserCommissionAmount { get; set; }

    public decimal? UserCommissionRate { get; set; }

    public decimal? UserFees { get; set; }

    public decimal? UserNetMoney { get; set; }

    public string? YellowKey { get; set; }
}
