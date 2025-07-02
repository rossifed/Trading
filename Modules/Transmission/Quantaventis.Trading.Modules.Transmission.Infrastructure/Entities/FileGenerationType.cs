using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;

public partial class FileGenerationType
{
    public int FileGenerationTypeId { get; set; }

    public string Mnemonic { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<ClearingBrokerCodeMapping> ClearingBrokerCodeMappings { get; } = new List<ClearingBrokerCodeMapping>();

    public virtual ICollection<CustodianCodeMapping> CustodianCodeMappings { get; } = new List<CustodianCodeMapping>();

    public virtual ICollection<ExecutionBrokerCodeMapping> ExecutionBrokerCodeMappings { get; } = new List<ExecutionBrokerCodeMapping>();

    public virtual ICollection<FileGenerationProfile> FileGenerationProfiles { get; } = new List<FileGenerationProfile>();
}
