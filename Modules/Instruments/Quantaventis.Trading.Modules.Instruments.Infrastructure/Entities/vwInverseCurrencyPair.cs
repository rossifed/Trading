using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class vwInverseCurrencyPair
{
    public int CurrencyPairId { get; set; }

    public string Symbol { get; set; } = null!;

    public byte BaseCurrencyId { get; set; }

    public string BaseCurrencyCode { get; set; } = null!;

    public byte QuoteCurrencyId { get; set; }

    public string QuoteCurrencyCode { get; set; } = null!;

    public int InverseCurrencyPairId { get; set; }

    public string InverseSymbol { get; set; } = null!;

    public byte InverseBaseCurrencyId { get; set; }

    public string InverseBaseCurrencyCode { get; set; } = null!;

    public byte InverseQuoteCurrencyId { get; set; }

    public string InverseQuoteCurrencyCode { get; set; } = null!;
}
