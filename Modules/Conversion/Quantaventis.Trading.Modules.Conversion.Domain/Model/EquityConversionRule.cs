using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class EquityConversionRule : IContractConversionRule
    {
        private InstrumentMapping EquityToCfdMapping { get; }
        private PortfolioId PortfolioId { get; }
        internal bool ConvertToCfd { get; }
        internal EquityConversionRule(PortfolioId portfolioId, bool convertToCfd, InstrumentMapping equityToCfdMapping)
        {
  this.PortfolioId= portfolioId;
            this.ConvertToCfd= convertToCfd;
            EquityToCfdMapping = equityToCfdMapping;


        }

       

        public TargetWeightConversion Apply(TargetWeight targetWeight)
        { 

                return new TargetWeightConversion(targetWeight, 
                    ConvertToCfd? 
                    EquityToCfdMapping.Map(targetWeight.Instrument) 
                    : targetWeight.Instrument,
                    targetWeight.Weight);
        }

        public bool ApplyTo(TargetWeight targetWeight)
        {
            return "EQU".Equals(targetWeight.InstrumentType);
        }
    }
}
