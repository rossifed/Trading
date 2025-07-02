using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;

public partial class VwFxForwardOrdersToFxgo
{
    public string Instrument { get; set; } = null!;

    public string? CurrencyPair { get; set; }

    public string? Side { get; set; }

    public string Tenor { get; set; } = null!;

    public string? ValueDate { get; set; }

    public int? Amount { get; set; }

    public string? Currency { get; set; }

    public string Account { get; set; } = null!;
}
