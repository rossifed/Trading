using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;

public partial class EmsxFill
{
    public string? Account { get; set; }

    public int Amount { get; set; }

    public string? AssetClass { get; set; }

    public int? BasketId { get; set; }

    public string? Bbgid { get; set; }

    public string? BlockId { get; set; }

    public string Broker { get; set; } = null!;

    public string? ClearingAccount { get; set; }

    public string? ClearingFirm { get; set; }

    public DateTime? ContractExpDate { get; set; }

    public int? CorrectedFillId { get; set; }

    public string Currency { get; set; } = null!;

    public string? Cusip { get; set; }

    public DateTime DateTimeOfFill { get; set; }

    public string Exchange { get; set; } = null!;

    public int? ExecPrevSeqNo { get; set; }

    public string? ExecType { get; set; }

    public string? ExecutingBroker { get; set; }

    public int FillId { get; set; }

    public decimal FillPrice { get; set; }

    public int FillShares { get; set; }

    public string? InvestorId { get; set; }

    public bool IsCfd { get; set; }

    public string? Isin { get; set; }

    public bool? IsLeg { get; set; }

    public string? LastCapacity { get; set; }

    public string? LastMarket { get; set; }

    public decimal? LimitPrice { get; set; }

    public string? Liquidity { get; set; }

    public string? LocalExchangeSymbol { get; set; }

    public string? LocateBroker { get; set; }

    public string? LocateId { get; set; }

    public bool? LocateRequired { get; set; }

    public string? MultiLegId { get; set; }

    public string? OccSymbol { get; set; }

    public string? OrderExecutionInstruction { get; set; }

    public string? OrderHandlingInstruction { get; set; }

    public int OrderId { get; set; }

    public string? OrderInstruction { get; set; }

    public string? OrderOrigin { get; set; }

    public string? OrderReferenceId { get; set; }

    public int? OriginatingTraderUuid { get; set; }

    public string? ReroutedBroker { get; set; }

    public decimal? RouteCommissionAmount { get; set; }

    public decimal? RouteCommissionRate { get; set; }

    public string? RouteExecutionInstruction { get; set; }

    public string? RouteHandlingInstruction { get; set; }

    public int? RouteId { get; set; }

    public decimal? RouteNetMoney { get; set; }

    public string? RouteNotes { get; set; }

    public int? RouteShares { get; set; }

    public string? SecurityName { get; set; }

    public string? Sedol { get; set; }

    public DateTime? SettlementDate { get; set; }

    public string Side { get; set; } = null!;

    public decimal? StopPrice { get; set; }

    public string? StrategyType { get; set; }

    public string Ticker { get; set; } = null!;

    public string? Tif { get; set; }

    public string? TraderName { get; set; }

    public int? TraderUuid { get; set; }

    public string? Type { get; set; }

    public decimal? UserCommissionAmount { get; set; }

    public decimal? UserCommissionRate { get; set; }

    public decimal? UserFees { get; set; }

    public decimal? UserNetMoney { get; set; }

    public string YellowKey { get; set; } = null!;
}
