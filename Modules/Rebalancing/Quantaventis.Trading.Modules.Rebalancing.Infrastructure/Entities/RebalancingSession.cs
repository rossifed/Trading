using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

public partial class RebalancingSession
{
    public int RebalancingSessionId { get; set; }

    public string Status { get; set; } = null!;

    public string StatusReason { get; set; } = null!;

    public DateTime TradeDate { get; set; }

    public DateTime StartedOn { get; set; }

    public DateTime? EndedOn { get; set; }

    public string StartedBy { get; set; } = null!;

    public virtual ICollection<PortfolioDrift> PortfolioDrifts { get; } = new List<PortfolioDrift>();
}
