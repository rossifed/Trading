using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class RebalancingId
    {
        internal int Id { get; }
        internal RebalancingId(int id) { 
        this.Id = id;
        }
 

        public static implicit operator RebalancingId(int id) => new(id);

        public static implicit operator int(RebalancingId portfolio) => portfolio.Id;



        public override string? ToString()
         => Id.ToString();

        public override bool Equals(object? obj)
        {
            return obj is RebalancingId id &&
                   Id == id.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
