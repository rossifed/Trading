using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;

public partial class EfrpOrder
{
    public int EfrpOrderId { get; set; }

    public int OriginalOrderId { get; set; }

    public int FutureContractId { get; set; }

    public int OriginalQuantity { get; set; }

    public string FxForwardSymbol { get; set; } = null!;

    public string BaseCurrency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public DateTime MaturityDate { get; set; }

    public int FxForwardQuantity { get; set; }

    public byte PortfolioId { get; set; }

    public int RebalancingId { get; set; }

    public string PositionSide { get; set; } = null!;

    public DateTime CreatedOn { get; set; }
}
