using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;

public partial class Trade
{
    public int TradeId { get; set; }

    public byte PortfolioId { get; set; }

    public int SecurityId { get; set; }

    public int Quantity { get; set; }

    public decimal ExecutionPrice { get; set; }

    public string Currency { get; set; } = null!;

    public DateTime ExecutedOn { get; set; }
}
