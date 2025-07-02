using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class FxForwardChain
    {

        internal CurrencyPair CurrencyPair { get; }

        internal Currency BaseCurrency => CurrencyPair.BaseCurrency;
        internal Currency QuoteCurrency => CurrencyPair.QuoteCurrency;
        internal IEnumerable<FxForward> FxForwards { get; }

        internal FxForwardChain(CurrencyPair CurrencyPair, IEnumerable<FxForward> FxForwards)
        {

            CurrencyPair = CurrencyPair;
            FxForwards = FxForwards;
        }


        internal FxForwardChain UpdateContractsFrom(FxForwardChain FxForwardChain)
        {
            IDictionary<CurrencyPair, FxForward> currentContracts = FxForwards.ToDictionary(x => x.CurrencyPair);
            FxForward UpdateOrAddContract(FxForward FxForward, IDictionary<CurrencyPair, FxForward> currentContracts)
            {
                var currency = FxForward.CurrencyPair;
                if (currentContracts.ContainsKey(currency))
                    return currentContracts[currency].UpdateFieldsFrom(FxForward);
                return FxForward;
            }
            var updatedContracts = FxForwardChain.FxForwards.Select(x => UpdateOrAddContract(x, currentContracts));

            return new FxForwardChain(CurrencyPair, updatedContracts);


        }

        internal bool HasSameContractsThan(FxForwardChain FxForwardChain)
        {
            IDictionary<CurrencyPair, FxForward> contractsToCompare = FxForwardChain.FxForwards.ToDictionary(x => x.CurrencyPair);

            bool FindAndCompare(FxForward FxForward, IDictionary<CurrencyPair, FxForward> contractsToCompare)
            {
                var currencyPair = FxForward.CurrencyPair;
                if (contractsToCompare.ContainsKey(currencyPair))
                    return FxForward.HasSameFieldsThan(contractsToCompare[currencyPair]);
                return false;
            }
            return FxForwards.All(x => FindAndCompare(x, contractsToCompare));
        }

    }
}
