using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Services
{
    internal interface IEfrpDetector {

        bool IsEfrp(int instrumentId);
    }

    internal class EfrpDetector  : IEfrpDetector
    {

        private IFutureContractLookup FutureContractLookup { get; }

        private IEfrpConversionRuleSelector EfrpSelectionRuleSelector { get; }
        public EfrpDetector(
            IEfrpConversionRuleSelector efrpSelectionRuleSelector,
            IFutureContractLookup futureContractLookup

         )
        
        {
          this.EfrpSelectionRuleSelector= efrpSelectionRuleSelector;
            this.FutureContractLookup= futureContractLookup;
        }
   

    
        public bool IsEfrp(int instrumentId)
        {
            FutureContract? futureContract = FutureContractLookup.FindByInstrumentId(instrumentId);
            if (futureContract != null)
            {
                EfrpConversionRule? convertionRule = EfrpSelectionRuleSelector.Select(futureContract);
                return convertionRule != null && convertionRule.IsActive;
              
            }
            return false;
        }

  
    }
}

