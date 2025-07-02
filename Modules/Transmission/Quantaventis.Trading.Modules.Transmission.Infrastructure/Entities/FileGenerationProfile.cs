using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class FileGenerationProfile
{
    public int FileGenerationProfileId { get; set; }

    public string FileName { get; set; } = null!;

    public bool IncludeHeader { get; set; }

    public string? DateParamFormat { get; set; }

    public string Separator { get; set; } = null!;

    public string OutputFolder { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte PortfolioId { get; set; }

    public string FunctionName { get; set; } = null!;

    public int TransmissionProfileId { get; set; }

    public int FileGenerationTypeId { get; set; }

    public virtual FileGenerationType FileGenerationType { get; set; } = null!;

    public virtual TransmissionProfile TransmissionProfile { get; set; } = null!;
}
