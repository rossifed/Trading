using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class EmailConfiguration
{
    public int EmailConfigurationId { get; set; }

    public string Recipients { get; set; } = null!;

    public string EmailSubject { get; set; } = null!;

    public string? MessageBody { get; set; }

    public bool AttachFile { get; set; }

    public virtual ICollection<TransmissionProfile> TransmissionProfiles { get; } = new List<TransmissionProfile>();
}
