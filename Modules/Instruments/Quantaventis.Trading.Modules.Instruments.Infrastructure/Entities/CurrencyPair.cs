using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class CurrencyPair
{
    public int CurrencyPairId { get; set; }

    public byte BaseCurrencyId { get; set; }

    public byte QuoteCurrencyId { get; set; }

    public decimal QuoteFactor { get; set; }

    public virtual Currency BaseCurrency { get; set; } = null!;

    public virtual Instrument CurrencyPairNavigation { get; set; } = null!;

    public virtual ICollection<FxForward> FxForwards { get; } = new List<FxForward>();

    public virtual Currency QuoteCurrency { get; set; } = null!;
}
