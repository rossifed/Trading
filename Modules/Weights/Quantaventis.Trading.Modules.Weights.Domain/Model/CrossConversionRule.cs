using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class CrossConversionRule : IContractConversionRule 
    {

        internal bool ConvertToForward { get; }

        internal bool InvertCross { get; }

        private InstrumentMapping CrossToInvertedMapping { get; }
        private InstrumentMapping CrossToForwardMapping { get; }

        private PortfolioId PortfolioId { get; }
        internal CrossConversionRule(
            PortfolioId portfolioId,
            InstrumentMapping crossToInvertedMapping,
            InstrumentMapping crossToForwardMapping,
            bool convertToForward,
            bool invertCross)
        {
            this.CrossToInvertedMapping = crossToInvertedMapping;
            this.CrossToForwardMapping =  crossToForwardMapping;
            this.InvertCross = invertCross;
            this.ConvertToForward = convertToForward;
            this.PortfolioId = portfolioId;
        
        }

        
        public  ConvertedWeight Apply(ModelWeight modelWeight)
        {

            ConvertedWeight ResolveForward(Instrument instrument, Weight weight)
             => ConvertToForward
                          ? new ConvertedWeight(modelWeight, CrossToForwardMapping.Map(instrument), weight)
                          : new ConvertedWeight(modelWeight, instrument, weight);

            return InvertCross
                ? ResolveForward(CrossToInvertedMapping.Map(modelWeight.Instrument), -modelWeight.Weight)
                : ResolveForward(modelWeight.Instrument, modelWeight.Weight);
        }

        public bool ApplyTo(ModelWeight modelWeight)
        {
           return modelWeight.Instrument.InstrumentType.Equals("CROSS") &&  modelWeight.PortfolioId.Equals(PortfolioId);

        }
    }
}
