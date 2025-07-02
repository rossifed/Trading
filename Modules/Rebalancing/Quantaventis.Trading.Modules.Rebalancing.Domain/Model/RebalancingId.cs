using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class RebalancingId
    {
        private int Id { get; }
        internal RebalancingId(int id) { 
        this.Id = id;
        }


        public static implicit operator RebalancingId(int id) => new(id);

        public static implicit operator int(RebalancingId rebalancingId) => rebalancingId.Id;

        public override string? ToString()
        {
            return Id.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is RebalancingId rebalancingid &&
                   Id == rebalancingid.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
