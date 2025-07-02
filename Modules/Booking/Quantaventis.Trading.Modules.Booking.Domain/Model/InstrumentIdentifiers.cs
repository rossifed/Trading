namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class InstrumentIdentifiers
    {
        internal string? Isin { get; set; }
        internal string? Sedol { get; set; }
        internal string? Cusip { get; set; }
        internal string Symbol { get; set; }
        internal string? SecurityName { get; set; }
        internal string? LocalExchangeSymbol { get; set; }
        internal string YellowKey { get; set; }

        public InstrumentIdentifiers(
            string symbol,
            string yellowKey)
        {
            Symbol = symbol;
            YellowKey = yellowKey;
        }
        public InstrumentIdentifiers(
            string symbol,
            string? isin,
            string? sedol,
            string? cusip,
            string? securityName,
            string? localExchangeSymbol,
            string yellowKey)
        {
            Symbol = symbol;
            Cusip = cusip;
            Isin = isin;
            Sedol = sedol;
            SecurityName = securityName;
            LocalExchangeSymbol = localExchangeSymbol;
            YellowKey = yellowKey;
        }

        internal InstrumentIdentifiers CleanName(Instrument instrument)
        {
            return new InstrumentIdentifiers(Symbol, Isin, Sedol, Cusip, instrument.Name, LocalExchangeSymbol, YellowKey);
        }
    }
}
