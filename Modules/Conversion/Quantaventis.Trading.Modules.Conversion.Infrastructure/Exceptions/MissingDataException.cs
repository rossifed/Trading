using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Infrastructure.Exceptions
{
    internal class MissingDataException :Exception
    {
        internal MissingDataException(string message) : base(message) { }
    }
}
