using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class EquityConversionRule
{
    public int EquityConversionRuleId { get; set; }

    public byte? PortfolioId { get; set; }

    public bool ConvertToCfd { get; set; }
}
