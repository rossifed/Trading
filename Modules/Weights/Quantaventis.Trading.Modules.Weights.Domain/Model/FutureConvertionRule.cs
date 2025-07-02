using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Domain.Model
{
    internal class FutureConversionRule : IContractConversionRule
    {

       private InstrumentMapping GenericToFutureContractMapping { get; }
        private InstrumentMapping GenericToCrossForwardMapping { get; }

        internal FutureConversionRule(InstrumentMapping genericToFutureContractMapping, InstrumentMapping genericToCrossForwardMapping) 
        {  

            this.GenericToFutureContractMapping = genericToFutureContractMapping;
            this.GenericToCrossForwardMapping =     genericToCrossForwardMapping;
      
        }

        public ConvertedWeight Apply(ModelWeight modelWeight)
        {
            if (GenericToCrossForwardMapping.IsMapable(modelWeight.Instrument)) { 
                return new ConvertedWeight(modelWeight, GenericToCrossForwardMapping.Map(modelWeight.Instrument), modelWeight.Weight);
            }
           return new ConvertedWeight(modelWeight, GenericToFutureContractMapping.Map(modelWeight.Instrument), modelWeight.Weight);
        }


        public bool ApplyTo(ModelWeight modelWeight)
        {
            return modelWeight.Instrument.InstrumentType.Equals("GENFUT");
        }
    }
}
