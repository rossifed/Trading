using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class TransmittedFile
{
    public int TransmittedFileId { get; set; }

    public int FileTransmissionId { get; set; }

    public string FileName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int RowsCount { get; set; }

    public virtual FileTransmission FileTransmission { get; set; } = null!;
}
