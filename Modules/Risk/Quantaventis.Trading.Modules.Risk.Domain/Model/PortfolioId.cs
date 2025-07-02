using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class PortfolioId
    {
        private byte Id { get; }
        internal PortfolioId(byte id) { 
        this.Id = id;
        }
 

        public static implicit operator PortfolioId(byte id) => new(id);

        public static implicit operator byte(PortfolioId portfolio) => portfolio.Id;



        public override string? ToString()
         => Id.ToString();

        public override bool Equals(object? obj)
        {
            return obj is PortfolioId id &&
                   Id == id.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
