using Quantaventis.Trading.Modules.Weights.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Exceptions
{
    internal class InstrumentMappingException : Exception
    {
        internal Instrument Instrument { get; }
        public InstrumentMappingException(Instrument instrument, string mappingType) : base($"No mapping of type {mappingType} was found for the instrument: {instrument} could not be mapped"){ 
                this.Instrument = instrument;
        }
    }
}
