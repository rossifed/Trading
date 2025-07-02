using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class VwTransmittedFile
{
    public int TransmittedFileId { get; set; }

    public int FileTransmissionId { get; set; }

    public string ContentType { get; set; } = null!;

    public string Counterparty { get; set; } = null!;

    public bool IsFtpTransmitted { get; set; }

    public DateTime? TransmittedOn { get; set; }

    public string TransmissionType { get; set; } = null!;

    public bool IsEmailTransmitted { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int RowsCount { get; set; }
}
