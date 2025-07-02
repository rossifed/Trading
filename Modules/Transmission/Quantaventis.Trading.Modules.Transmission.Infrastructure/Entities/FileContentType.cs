using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class FileContentType
{
    public byte FileContentTypeId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<TransmissionProfile> TransmissionProfiles { get; } = new List<TransmissionProfile>();
}
