using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;

public partial class VwEfrpConversionRule
{
    public int EfrpConversionRuleId { get; set; }

    public int GenericFutureId { get; set; }

    public string RootSymbol { get; set; } = null!;

    public string Symbol { get; set; } = null!;

    public decimal ContractSize { get; set; }

    public int BrokerId { get; set; }

    public string BaseCurrency { get; set; } = null!;

    public string QuoteCurrency { get; set; } = null!;

    public string CmeClearportTicker { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }
}
