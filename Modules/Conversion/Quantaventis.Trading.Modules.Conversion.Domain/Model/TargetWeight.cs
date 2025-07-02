using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class TargetWeight
    {
        internal Instrument Instrument { get; }
        internal string InstrumentType => Instrument.InstrumentType;
        internal InstrumentId InstrumentId => Instrument.Id;
        internal PortfolioId PortfolioId { get; }
        internal Weight Weight { get;  }
   
        internal TargetWeight(PortfolioId portfolioId,Instrument instrument, Weight weight)
        {
    
            this.PortfolioId = portfolioId;
  
            this.Instrument = instrument;
            this.Weight = weight;
        }


        public override string? ToString()
            => $"{PortfolioId} {Instrument} {Weight}";

        public override bool Equals(object? obj)
        {
            return obj is TargetWeight weight &&
                   EqualityComparer<InstrumentId>.Default.Equals(InstrumentId, weight.InstrumentId) &&
                   EqualityComparer<PortfolioId>.Default.Equals(PortfolioId, weight.PortfolioId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(InstrumentId, PortfolioId);
        }
    }
}
