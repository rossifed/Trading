using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rolling.Domain.Model
{
    internal class RollableContract
    {
        internal int GenericId { get; }
    
        internal int ContractId { get; }

        public RollableContract(int genericId, int contractId)
        {
            GenericId = genericId;
            ContractId = contractId;
        }

        public override bool Equals(object? obj)
        {
            return obj is RollableContract contract &&
                   GenericId == contract.GenericId &&
                   ContractId == contract.ContractId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GenericId, ContractId);
        }


    }
}
