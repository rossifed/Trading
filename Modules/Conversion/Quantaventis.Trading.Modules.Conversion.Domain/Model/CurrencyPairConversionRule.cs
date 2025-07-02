using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class CurrencyPairConversionRule : IContractConversionRule 
    {

        internal bool ConvertToForward { get; }

        internal bool InvertCurrencyPair { get; }

        private InstrumentMapping CurrencyPairToInvertedMapping { get; }
        private InstrumentMapping CurrencyPairToForwardMapping { get; }

        private PortfolioId PortfolioId { get; }
        internal CurrencyPairConversionRule(
            PortfolioId portfolioId,
            InstrumentMapping CurrencyPairToInvertedMapping,
            InstrumentMapping CurrencyPairToForwardMapping,
            bool convertToForward,
            bool invertCurrencyPair)
        {
            this.CurrencyPairToInvertedMapping = CurrencyPairToInvertedMapping;
            this.CurrencyPairToForwardMapping =  CurrencyPairToForwardMapping;
            this.InvertCurrencyPair = invertCurrencyPair;
            this.ConvertToForward = convertToForward;
            this.PortfolioId = portfolioId;
        
        }

        
        public  TargetWeightConversion Apply(TargetWeight TargetWeight)
        {

            TargetWeightConversion ResolveForward(Instrument instrument, Weight weight)
             => ConvertToForward
                          ? new TargetWeightConversion(TargetWeight, CurrencyPairToForwardMapping.Map(instrument), weight)
                          : new TargetWeightConversion(TargetWeight, instrument, weight);

            return InvertCurrencyPair
                ? ResolveForward(CurrencyPairToInvertedMapping.Map(TargetWeight.Instrument), -TargetWeight.Weight)
                : ResolveForward(TargetWeight.Instrument, TargetWeight.Weight);
        }

   

        public bool ApplyTo(TargetWeight targetWeight)
        {
         return targetWeight.InstrumentType.Equals("CROSS") && targetWeight.PortfolioId.Equals(PortfolioId);

        }
    }
}
