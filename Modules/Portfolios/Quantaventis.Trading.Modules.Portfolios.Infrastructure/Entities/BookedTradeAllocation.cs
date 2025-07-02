using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;

public partial class BookedTradeAllocation
{
    public int TradeId { get; set; }

    public int TradeAllocationId { get; set; }

    public byte PortfolioId { get; set; }

    public int InstrumentId { get; set; }

    public bool IsSwap { get; set; }

    public int Quantity { get; set; }

    public decimal TradePrice { get; set; }

    public decimal GrossAmount { get; set; }

    public decimal NetAmount { get; set; }

    public decimal Commission { get; set; }

    public decimal Fees { get; set; }

    public string TradeCurrency { get; set; } = null!;

    public DateTime LastTradeDate { get; set; }

    public virtual Instrument Instrument { get; set; } = null!;

    public virtual Portfolio Portfolio { get; set; } = null!;
}
