using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwTransmissionProfile
{
    public int TransmissionProfileId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsEnabled { get; set; }

    public int CounterPartyId { get; set; }

    public string? CounterPartyName { get; set; }

    public byte FileContentTypeId { get; set; }

    public string? FileContentType { get; set; }

    public int? FtpConfigurationId { get; set; }

    public string? FtpHost { get; set; }

    public string? FtpUser { get; set; }

    public int? FtpPort { get; set; }

    public string? FtpRemoteFolder { get; set; }

    public int? EmailConfigurationId { get; set; }

    public int? EncryptionProfileId { get; set; }

    public string? ExcryptedFileExtension { get; set; }

    public bool? EncryptAndSign { get; set; }

    public int TransmissionScheduleTypeId { get; set; }

    public string? TransmissionScheduleType { get; set; }
}
