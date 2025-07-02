using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class TransmissionProfile
{
    public int TransmissionProfileId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public int CounterPartyId { get; set; }

    public int? FtpConfigurationId { get; set; }

    public int? EmailConfigurationId { get; set; }

    public int? EncryptionProfileId { get; set; }

    public string Description { get; set; } = null!;

    public int TransmissionScheduleTypeId { get; set; }

    public bool IsEnabled { get; set; }

    public byte FileContentTypeId { get; set; }

    public virtual Counterparty CounterParty { get; set; } = null!;

    public virtual EmailConfiguration? EmailConfiguration { get; set; }

    public virtual EncryptionProfile? EncryptionProfile { get; set; }

    public virtual FileContentType FileContentType { get; set; } = null!;

    public virtual ICollection<FileGenerationProfile> FileGenerationProfiles { get; } = new List<FileGenerationProfile>();

    public virtual FtpConfiguration? FtpConfiguration { get; set; }

    public virtual TransmissionScheduleType TransmissionScheduleType { get; set; } = null!;
}
