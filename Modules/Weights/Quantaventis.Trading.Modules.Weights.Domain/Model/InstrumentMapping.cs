using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class InstrumentMapping : IInstrumentMapping
    {
       private IDictionary<Instrument, Instrument> MappingDic { get; }

        private string MappingType { get; }
        internal InstrumentMapping(string mappingType, IDictionary<Instrument, Instrument> mappingDic) 
        {
            this.MappingType = mappingType;
            this.MappingDic = mappingDic;
        }

        public bool IsMapable(Instrument instrument) 
            => MappingDic.ContainsKey(instrument);
        public Instrument Map(Instrument instrument)
            => MappingDic[instrument];


    }
}
