using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class FutureConversionRule : IContractConversionRule
    {

       private InstrumentMapping GenericToFutureContractMapping { get; }
        private InstrumentMapping GenericToFxForwardMapping { get; }

        internal FutureConversionRule(InstrumentMapping genericToFutureContractMapping, InstrumentMapping genericToFxForwardMapping) 
        {  

            this.GenericToFutureContractMapping = genericToFutureContractMapping;
            this.GenericToFxForwardMapping =     genericToFxForwardMapping;
      
        }

        public TargetWeightConversion Apply(TargetWeight TargetWeight)
        {
            //if (GenericToFxForwardMapping.IsMapable(TargetWeight.Instrument)) 
            //    return new TargetWeightConversion(TargetWeight, GenericToFxForwardMapping.Map(TargetWeight.Instrument), TargetWeight.Weight);
            
            if(GenericToFutureContractMapping.IsMapable(TargetWeight.Instrument))
             return new TargetWeightConversion(TargetWeight, GenericToFutureContractMapping.Map(TargetWeight.Instrument), TargetWeight.Weight);

            throw new InvalidOperationException($"The Instrument {TargetWeight.Instrument} couldn't be mapped");
        }

       
        public bool ApplyTo(TargetWeight targetWeight)
        {
            return targetWeight.InstrumentType.Equals("GENFUT");
        }
    }
}
