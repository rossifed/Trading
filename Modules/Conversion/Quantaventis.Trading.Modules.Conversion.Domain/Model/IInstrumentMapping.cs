using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal interface IInstrumentMapping
    {

        Instrument Map(Instrument instrument);

    }
}
