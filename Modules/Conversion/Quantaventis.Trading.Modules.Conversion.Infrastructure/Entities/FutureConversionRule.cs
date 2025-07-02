using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class FutureConversionRule
{
    public int FutureConversionRuleId { get; set; }

    public byte? PortfolioId { get; set; }

    public bool ConvertToCross { get; set; }
}
