namespace Quantaventis.Trading.Modules.Valuation.Domain.Model
{
    internal  struct InstrumentType
    {   

        internal  string Mnemonic { get; }
        private InstrumentType(string mnemonic) {
            this.Mnemonic = mnemonic;
        }

        public override string? ToString()
        {
            return Mnemonic;
        }

        internal static readonly InstrumentType Equity  = new InstrumentType("EQU");

        internal static readonly InstrumentType Future = new InstrumentType("FUT");
       
        internal static readonly InstrumentType FxForward = new InstrumentType("CurrencyPairFWD");

        private static readonly Dictionary<string, InstrumentType> MnemonicToTypeMap = new Dictionary<string, InstrumentType>
    {
        { Equity.Mnemonic, Equity },
        { Future.Mnemonic, Future },
        { FxForward.Mnemonic, FxForward }
    };
        public static InstrumentType FromMnemonic(string mnemonic) {

            switch (mnemonic) { 
          
            }
            if (MnemonicToTypeMap.TryGetValue(mnemonic, out var instrumentType))
            {
                return instrumentType;
            }
            else
            {
                throw new ArgumentException($"Unknown Instrument Type mnemonic: {mnemonic}");
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is InstrumentType type &&
                   Mnemonic == type.Mnemonic;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Mnemonic);
        }
    }
}
