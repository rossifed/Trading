using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class FtpConfiguration
{
    public int FtpConfigurationId { get; set; }

    public string Host { get; set; } = null!;

    public int Port { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsSftp { get; set; }

    public string RemoteFolder { get; set; } = null!;

    public virtual ICollection<TransmissionProfile> TransmissionProfiles { get; } = new List<TransmissionProfile>();
}
