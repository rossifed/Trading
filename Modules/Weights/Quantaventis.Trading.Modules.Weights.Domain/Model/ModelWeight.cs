using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class ModelWeight
    {
        internal Instrument Instrument { get; }

        internal InstrumentId InstrumentId => Instrument.Id;
        internal PortfolioId PortfolioId { get; }
        internal Weight Weight { get;  }
        internal DateTime GeneratedOn { get; }
        internal ModelWeight(PortfolioId portfolioId,Instrument instrument, Weight weight, DateTime generatedOn)
        {
            this.PortfolioId = portfolioId;
            this.Instrument = instrument;
            this.Weight = weight;
            this.GeneratedOn = generatedOn;
        }


        public override string? ToString()
            => $"{Instrument} {Weight}";

        public override bool Equals(object? obj)
        {
            return obj is ModelWeight weight &&
                   EqualityComparer<Instrument>.Default.Equals(Instrument, weight.Instrument) &&
                   EqualityComparer<Weight>.Default.Equals(Weight, weight.Weight) &&
                   GeneratedOn == weight.GeneratedOn;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Instrument, Weight, GeneratedOn);
        }
    }
}
