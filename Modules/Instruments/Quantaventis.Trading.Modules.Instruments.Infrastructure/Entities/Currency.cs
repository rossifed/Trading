using System;
using System.Collections.Generic;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

public partial class Currency
{
    public byte CurrencyId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<CurrencyPair> CurrencyPairBaseCurrencies { get; } = new List<CurrencyPair>();

    public virtual ICollection<CurrencyPair> CurrencyPairQuoteCurrencies { get; } = new List<CurrencyPair>();

    public virtual ICollection<Instrument> InstrumentCurrencies { get; } = new List<Instrument>();

    public virtual ICollection<Instrument> InstrumentQuoteCurrencies { get; } = new List<Instrument>();
}
