using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class ConvertedWeight 
    {

        internal Instrument TargetInstrument { get; }
        internal InstrumentId TargetInstrumentId => TargetInstrument.Id;
        internal Weight TargetWeight { get;  }
        internal ModelWeight SourceModelWeight { get; }
        internal InstrumentId SourceInstrumentId => SourceModelWeight.InstrumentId;
        internal Weight SourceWeight => SourceModelWeight.Weight;
        internal ConvertedWeight(ModelWeight modelWeight, Instrument instrument, Weight weight)

        {
            this.SourceModelWeight = modelWeight;
            this.TargetInstrument = instrument;
            this.TargetWeight = weight;
        }


        public override string? ToString()
         => $"{TargetInstrument} {TargetWeight}";
    }
}
