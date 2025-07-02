using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class EquityConversionRule : IContractConversionRule 
    {
        private PortfolioId PortfolioId { get; }
        private bool ConvertToCfd { get; }
        private InstrumentMapping EquityToCfdMapping { get; }
  


        internal EquityConversionRule(
            PortfolioId portfolioId,
            bool convertToCfd,
            InstrumentMapping equityToCfdMapping)
        {
            this.PortfolioId = portfolioId;
            this.ConvertToCfd = convertToCfd;
            this.EquityToCfdMapping = equityToCfdMapping;
        
        }

       

        public ConvertedWeight Apply(ModelWeight modelWeight)
        {

            if (ConvertToCfd)
                return new ConvertedWeight(modelWeight, EquityToCfdMapping.Map(modelWeight.Instrument), modelWeight.Weight);
            else 
                return new ConvertedWeight(modelWeight, modelWeight.Instrument, modelWeight.Weight);
        }

        public bool ApplyTo(ModelWeight modelWeight)
        {
            return modelWeight.Instrument.InstrumentType.Equals("EQU") && modelWeight.PortfolioId.Equals(PortfolioId);
        }
    }
}
