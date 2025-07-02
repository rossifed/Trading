using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class InstrumentMapping : IInstrumentMapping
    {
       private IDictionary<Instrument, Instrument> MappingDic { get; }

        private InstrumentMappingType MappingType { get; }
        internal InstrumentMapping(InstrumentMappingType mappingType, IDictionary<Instrument, Instrument> mappingDic) 
        {
            this.MappingType = mappingType;
            this.MappingDic = mappingDic;
        }
        public static InstrumentMapping Empty(InstrumentMappingType mappingType)
            => new InstrumentMapping(mappingType, new Dictionary<Instrument, Instrument>());
        public bool IsMapable(Instrument instrument) 
            => MappingDic.ContainsKey(instrument);
        public Instrument Map(Instrument instrument)
            => MappingDic[instrument];


    }
}
