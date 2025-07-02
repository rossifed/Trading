using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Entities;

public partial class Position
{
    public byte PortfolioId { get; set; }

    public DateTime PositionDate { get; set; }

    public int Quantity { get; set; }

    public decimal NominalQuantity { get; set; }

    public int InstrumentId { get; set; }

    public string LocalCurrency { get; set; } = null!;

    public string BaseCurrency { get; set; } = null!;

    public decimal GrossEntryPriceLocal { get; set; }

    public decimal GrossEntryPriceBase { get; set; }

    public decimal NetEntryPriceLocal { get; set; }

    public decimal NetEntryPriceBase { get; set; }

    public decimal GrossTradeValueLocal { get; set; }

    public decimal GrossTradeValueBase { get; set; }

    public decimal NetTradeValueLocal { get; set; }

    public decimal NetTradeValueBase { get; set; }

    public decimal GrossNotionalValueLocal { get; set; }

    public decimal GrossNotionalValueBase { get; set; }

    public decimal NetNotionalValueLocal { get; set; }

    public decimal NetNotionalValueBase { get; set; }

    public decimal TotalCommissionLocal { get; set; }

    public decimal TotalCommissionBase { get; set; }

    public bool IsSwap { get; set; }

    public DateTime FirstTradeDate { get; set; }

    public DateTime LastTradeDate { get; set; }

    public virtual Instrument Instrument { get; set; } = null!;
}
