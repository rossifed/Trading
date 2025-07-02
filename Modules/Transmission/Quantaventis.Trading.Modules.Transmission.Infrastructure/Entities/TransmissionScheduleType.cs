using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class TransmissionScheduleType
{
    public int TransmissionScheduleTypeId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<TransmissionProfile> TransmissionProfiles { get; } = new List<TransmissionProfile>();
}
