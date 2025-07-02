using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class TradeAllocation
{
    public int TradeAllocationId { get; set; }

    public int TradeId { get; set; }

    public string TradeStatus { get; set; } = null!;

    public byte PortfolioId { get; set; }

    public string PositionSide { get; set; } = null!;

    public int Quantity { get; set; }

    public decimal NominalQuantity { get; set; }

    public int OrderAllocationQuantity { get; set; }

    public decimal OrderAllocationNominalQuantity { get; set; }

    public decimal ContractMultiplier { get; set; }

    public string LocalCurrency { get; set; } = null!;

    public string BaseCurrency { get; set; } = null!;

    public string SettlementCurrency { get; set; } = null!;

    public decimal CommissionValue { get; set; }

    public string CommissionType { get; set; } = null!;

    public decimal GrossAvgPriceLocal { get; set; }

    public decimal PriceCommissionLocal { get; set; }

    public decimal NetAvgPriceLocal { get; set; }

    public decimal GrossAvgPriceBase { get; set; }

    public decimal PriceCommissionBase { get; set; }

    public decimal NetAvgPriceBase { get; set; }

    public decimal? GrossAvgPriceSettle { get; set; }

    public decimal? PriceCommissionSettle { get; set; }

    public decimal? NetAvgPriceSettle { get; set; }

    public decimal CommissionAmountLocal { get; set; }

    public decimal CommissionAmountBase { get; set; }

    public decimal? CommissionAmountSettle { get; set; }

    public decimal MiscFeesLocal { get; set; }

    public decimal MiscFeesBase { get; set; }

    public decimal MiscFeesSettle { get; set; }

    public decimal GrossTradeValueLocal { get; set; }

    public decimal NetTradeValueLocal { get; set; }

    public decimal GrossTradeValueBase { get; set; }

    public decimal NetTradeValueBase { get; set; }

    public decimal GrossTradeValueSettle { get; set; }

    public decimal? NetTradeValueSettle { get; set; }

    public decimal GrossPrincipalLocal { get; set; }

    public decimal NetPrincipalLocal { get; set; }

    public decimal GrossPrincipalBase { get; set; }

    public decimal NetPrincipalBase { get; set; }

    public decimal GrossPrincipalSettle { get; set; }

    public decimal NetPrincipalSettle { get; set; }

    public DateTime SettlementDate { get; set; }

    public decimal LocalToBaseFxRate { get; set; }

    public decimal LocalToSettleFxRate { get; set; }

    public string? PrimeBroker { get; set; }

    public string ClearingBroker { get; set; } = null!;

    public string ClearingAccount { get; set; } = null!;

    public string? Custodian { get; set; }

    public DateTime? LastCorrectedOnUtc { get; set; }

    public DateTime? CanceledOnUtc { get; set; }

    public virtual Trade Trade { get; set; } = null!;
}
