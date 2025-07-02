using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class FileTransmission
{
    public int FileTransmissionId { get; set; }

    public string TransmissionType { get; set; } = null!;

    public DateTime? TransmittedOn { get; set; }

    public bool IsFtpTransmitted { get; set; }

    public bool IsEmailTransmitted { get; set; }

    public string Counterparty { get; set; } = null!;

    public string ContentType { get; set; } = null!;

    public virtual ICollection<TransmittedFile> TransmittedFiles { get; } = new List<TransmittedFile>();
}
