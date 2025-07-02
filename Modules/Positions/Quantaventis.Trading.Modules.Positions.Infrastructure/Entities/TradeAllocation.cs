using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Entities;

public partial class TradeAllocation
{
    public int TradeAllocationId { get; set; }

    public int TradeId { get; set; }

    public byte PortfolioId { get; set; }

    public int InstrumentId { get; set; }

    public DateTime TradeDate { get; set; }

    public bool IsSwap { get; set; }

    public string? Isin { get; set; }

    public string? Sedol { get; set; }

    public string? Cusip { get; set; }

    public string? SecurityName { get; set; }

    public int Quantity { get; set; }

    public decimal NominalQuantity { get; set; }

    public string LocalCurrency { get; set; } = null!;

    public string BaseCurrency { get; set; } = null!;

    public decimal GrossAvgPriceLocal { get; set; }

    public decimal GrossAvgPriceBase { get; set; }

    public decimal NetAvgPriceLocal { get; set; }

    public decimal NetAvgPriceBase { get; set; }

    public decimal CommissionAmountLocal { get; set; }

    public decimal CommissionAmountBase { get; set; }

    public decimal GrossTradeValueLocal { get; set; }

    public decimal NetTradeValueLocal { get; set; }

    public decimal GrossTradeValueBase { get; set; }

    public decimal NetTradeValueBase { get; set; }

    public decimal GrossPrincipalLocal { get; set; }

    public decimal NetPrincipalLocal { get; set; }

    public decimal GrossPrincipalBase { get; set; }

    public decimal NetPrincipalBase { get; set; }

    public decimal LocalToBaseFxRate { get; set; }

    public decimal LocalToSettleFxRate { get; set; }
}
