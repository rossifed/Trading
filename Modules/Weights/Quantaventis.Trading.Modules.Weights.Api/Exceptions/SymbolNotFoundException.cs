using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Api.Exceptions
{
    internal class SymbolNotFoundException :Exception
    {
        internal IEnumerable<string> UnmappedSymbols { get; }
        public SymbolNotFoundException(IEnumerable<string> unmappedSymbols) : base($"The following symbols could not be found: {string.Join(',', unmappedSymbols)}")
        {
            UnmappedSymbols = unmappedSymbols;


        }

    }
}
