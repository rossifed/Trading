using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal struct InstrumentMappingType { 

        internal byte Id { get; }
        internal string Mnemonic { get; }

        public InstrumentMappingType(byte id, string mnemonic)
        {
            Id = id;
            Mnemonic = mnemonic;
        }
        internal static InstrumentMappingType GenericToFuture
     => new InstrumentMappingType(1, "GENERIC2FUTURE");
        internal static InstrumentMappingType CurrencyPairToForward 
            => new InstrumentMappingType(2, "CURNCYPAIR2FORWARD");

        internal static InstrumentMappingType CurrencyPairToInverse
          => new InstrumentMappingType(3, "CURNCYPAIR2INVERSE");

        internal static InstrumentMappingType FutureToForward
         => new InstrumentMappingType(4, "FUTURE2FORWARD");

        internal static InstrumentMappingType EquityToCfd
            => new InstrumentMappingType(5, "EQU2CFD");



    }
}
