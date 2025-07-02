using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class TargetWeightConversion 
    {
        internal PortfolioId PortfolioId { get; }
        internal Instrument ToInstrument { get; }
        internal InstrumentId ToInstrumentId => ToInstrument.Id;
        internal Weight ToWeight { get;  }
        internal TargetWeight FromTargetWeight { get; }

        internal Instrument FromInstrument => FromTargetWeight.Instrument;
        internal InstrumentId FromInstrumentId => FromTargetWeight.InstrumentId;
        internal Weight FromWeight => FromTargetWeight.Weight;
        internal TargetWeightConversion(TargetWeight fromTargetWeight, Instrument toInstrument, Weight toWeight)

        {
            this.FromTargetWeight = fromTargetWeight;
            this.PortfolioId = fromTargetWeight.PortfolioId;
            this.ToInstrument = toInstrument;
            this.ToWeight = toWeight;
        }


        public override string? ToString()
         => $"From:{FromInstrument} {FromWeight}, To:{ToInstrument} {ToWeight}";
    }
}
