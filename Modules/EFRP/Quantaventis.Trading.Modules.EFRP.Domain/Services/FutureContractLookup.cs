using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Domain.Services
{
    internal interface IFutureContractLookup {


        bool Exists(int instrumentId);
        FutureContract? FindByInstrumentId(int instrumentId);
    }
    internal class FutureContractLookup : IFutureContractLookup
    { 

        private IEnumerable<FutureContract> FutureContracts { get; }

        public FutureContractLookup(IEnumerable<FutureContract> futureContracts)
        {
            FutureContracts = futureContracts;
        }

    
 
        public bool Exists(int instrumentId)
        {
            return FutureContracts.Any(x => x.Id == instrumentId);

        }
        public FutureContract? FindByInstrumentId(int instrumentId)
        {
            return FutureContracts
                .FirstOrDefault(x => x.Id == instrumentId);

        }
    }
}
