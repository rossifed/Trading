using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Services
{
    internal interface IEfrpConversionInfoProvider {
        EfrpConversionInfo GetEfrpConversionInfo(IEfrpCandidate order);
        IEnumerable<EfrpConversionInfo> GetEfrpConversionInfos(IEnumerable<IEfrpCandidate> orders);
    }

    internal class EfrpConversionInfoProvider : IEfrpConversionInfoProvider
    {
        private IIMMDateProvider IMMDateProvider { get; }

        private IFutureContractLookup FutureContractLookup { get; }

        private IEfrpConversionRuleSelector EfrpSelectionRuleSelector { get; }

        public EfrpConversionInfoProvider(
            IEfrpConversionRuleSelector efrpSelectionRuleSelector,
            IFutureContractLookup futureContractLookup,
            IIMMDateProvider iMMDateProvider
         )

        {
            this.EfrpSelectionRuleSelector = efrpSelectionRuleSelector;
            this.FutureContractLookup = futureContractLookup;
            this.IMMDateProvider = iMMDateProvider;
        }


        public IEnumerable<EfrpConversionInfo> GetEfrpConversionInfos(IEnumerable<IEfrpCandidate> orders)
        {
            return orders.Select(x => GetEfrpConversionInfo(x)).ToList();
        }


        public EfrpConversionInfo GetEfrpConversionInfo(IEfrpCandidate efrpCandidate)
        {

            FutureContract? futureContract = FutureContractLookup.FindByInstrumentId(efrpCandidate.InstrumentId);
            if (futureContract != null)
            {
                EfrpConversionRule? convertionRule = EfrpSelectionRuleSelector.Select(futureContract) ?? null;
                if (convertionRule != null)
                {
                    DateOnly nextIMMDate = IMMDateProvider.GetNextIMMDate(futureContract.LastTradeDate);
                    FxForward fxForward= convertionRule.GetFxForward(nextIMMDate);
                    return new EfrpConversionInfo(efrpCandidate, futureContract, fxForward, convertionRule.IsActive);

                }
            }
            return new EfrpConversionInfo(efrpCandidate);
        }


    }
}

