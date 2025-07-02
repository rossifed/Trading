using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Domain.Model
{
    internal class FutureContractChain
    {
        internal string GenericFutureSymbol { get; }
        internal DateOnly LastTradeDateStart => FutureContracts.Select(x => x.LastTradeDate).Last();

        internal DateOnly LastTradeDateEnd=> FutureContracts.Select(x => x.LastTradeDate).First();

        internal DateOnly FirstNoticeDateStart => FutureContracts.Select(x => x.FirstNoticeDate).Last();

        internal DateOnly FirstNoticeDateEnd => FutureContracts.Select(x => x.FirstNoticeDate).First();
        internal IEnumerable<FutureContract> FutureContracts { get; }

        public FutureContractChain(string genericFutureSymbol, IEnumerable<FutureContract> futureContracts)
        {
            GenericFutureSymbol = genericFutureSymbol;
            FutureContracts = futureContracts;
        }

        internal FutureContractChain UpdateContractsFrom(FutureContractChain futureContractChain)
        {
            IDictionary<string, FutureContract> currentContracts = FutureContracts.ToDictionary(x => x.Symbol);
            FutureContract UpdateOrAddContract(FutureContract futureContract, IDictionary<string, FutureContract> currentContracts)
            {
                var symbol = futureContract.Symbol;
                if (currentContracts.ContainsKey(symbol))
                    return currentContracts[symbol].UpdateFieldsFrom(futureContract);
                return futureContract;
            }
             var updatedContracts = futureContractChain.FutureContracts.Select(x => UpdateOrAddContract(x, currentContracts));

            return new FutureContractChain(GenericFutureSymbol, updatedContracts);

       
        }

        internal bool HasSameContractsThan(FutureContractChain futureContractChain)
        {
            IDictionary<string, FutureContract> contractsToCompare = futureContractChain.FutureContracts.ToDictionary(x => x.Symbol);

            bool FindAndCompare(FutureContract futureContract,IDictionary<string, FutureContract> contractsToCompare)
            {
                var symbol = futureContract.Symbol;
                if (contractsToCompare.ContainsKey(symbol))
                    return futureContract.HasSameFieldsThan(contractsToCompare[symbol]);
                return false;
            }
            return FutureContracts.All(x=> FindAndCompare(x, contractsToCompare));
        }
    }

}
