using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;

public partial class CurrencyPairConversionRule
{
    public int CurrencyPairConversionRuleId { get; set; }

    public byte? PortfolioId { get; set; }

    public bool InvertPair { get; set; }

    public bool ConvertToForward { get; set; }
}
