using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Dto;

public partial class TradeAllocationDto
{
    public int TradeAllocationId { get; set; }

    public int TradeId { get; set; }

    public int? OrderAllocationId { get; set; }

    public byte PortfolioId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public string? PositionSide { get; set; }

    public string TradingAccount { get; set; } 
    public decimal Commission { get; set; }
    public decimal Fees { get; set; }
    public decimal NetAmount { get; set; }
    public decimal GrossAmount { get; set; }

}
