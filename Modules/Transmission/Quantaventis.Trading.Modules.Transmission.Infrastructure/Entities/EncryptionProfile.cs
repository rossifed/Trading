using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class EncryptionProfile
{
    public int EncryptionProfileId { get; set; }

    public string PublicKeyRecipient { get; set; } = null!;

    public string PrivateKeyRecipient { get; set; } = null!;

    public string? Passphrase { get; set; }

    public bool Sign { get; set; }

    public string ExcryptedFileExtension { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<TransmissionProfile> TransmissionProfiles { get; } = new List<TransmissionProfile>();
}
