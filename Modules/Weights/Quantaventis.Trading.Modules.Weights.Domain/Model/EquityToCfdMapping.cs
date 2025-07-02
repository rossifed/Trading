using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Weights.Domain.Exceptions;
namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class EquityToCfdMapping
    {

        private IDictionary<InstrumentId, InstrumentId> EquityToCfdDic { get; }

        internal InstrumentId Map(Instrument instrument) {
            if (EquityToCfdDic.ContainsKey(instrument.Id))
            {
                return EquityToCfdDic[instrument.Id];
            }
            else {
                throw new InstrumentMappingException(instrument, "EquityToCfd");
            }
        }
    }
}
