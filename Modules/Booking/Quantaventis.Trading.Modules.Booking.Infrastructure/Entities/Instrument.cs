using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

public partial class Instrument
{
    public int InstrumentId { get; set; }

    public string Symbol { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Isin { get; set; }

    public string BbgUniqueId { get; set; } = null!;

    public string InstrumentType { get; set; } = null!;

    public string MarketSector { get; set; } = null!;

    public string? Exchange { get; set; }

    public string? PrimaryMic { get; set; }

    public string Currency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public DateTime? MaturityDate { get; set; }

    public decimal PriceScalingFactor { get; set; }

    public decimal? FuturePointValue { get; set; }

    public int? GenericFutureId { get; set; }

    public virtual ICollection<CommissionSchedule> CommissionSchedules { get; } = new List<CommissionSchedule>();

    public virtual ICollection<CounterpartyRoleAssignment> CounterpartyRoleAssignments { get; } = new List<CounterpartyRoleAssignment>();

    public virtual Instrument? GenericFuture { get; set; }

    public virtual ICollection<Instrument> InverseGenericFuture { get; } = new List<Instrument>();

    public virtual ICollection<Position> Positions { get; } = new List<Position>();

    public virtual ICollection<SettlementInfo> SettlementInfos { get; } = new List<SettlementInfo>();
}
