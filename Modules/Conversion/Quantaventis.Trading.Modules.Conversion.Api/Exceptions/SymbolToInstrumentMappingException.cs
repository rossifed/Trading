using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Api.Exceptions
{
    internal class SymbolToInstrumentMappingException : Exception
    {
        internal IEnumerable<string> UnmappedSymbols { get; }
        internal SymbolToInstrumentMappingException(IEnumerable<string> unmappedSymbols) : base($"The following symbols could not be mapped: {string.Join(',', unmappedSymbols)}")
        {
            UnmappedSymbols = unmappedSymbols;


        }
    }
}
