using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public int? RebalancingId { get; set; }

    public int Quantity { get; set; }

    public DateTime TradeDate { get; set; }

    public string ExecutionDesk { get; set; } = null!;

    public string TradeMode { get; set; } = null!;

    public string ExecutionAccount { get; set; } = null!;

    public string OrderType { get; set; } = null!;

    public string ExecutionAlgo { get; set; } = null!;

    public string TimeInForce { get; set; } = null!;

    public virtual ICollection<OrderAllocation> OrderAllocations { get; } = new List<OrderAllocation>();
}
