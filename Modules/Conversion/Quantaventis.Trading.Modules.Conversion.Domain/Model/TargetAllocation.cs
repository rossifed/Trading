using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Domain.Model
{
    internal class TargetAllocation
    {

        internal int Id { get; }
   

        internal PortfolioId PortfolioId { get; }

        internal DateTime GeneratedOn { get; }
        internal TargetAllocation(int id,
            PortfolioId portfolioId,
            DateTime generatedOn)
        {

            this.Id = id;
            this.PortfolioId = portfolioId;
            this.GeneratedOn = generatedOn;
 
        }

        public override bool Equals(object? obj)
        {
            return obj is TargetAllocation allocation &&
                   Id == allocation.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return $"Allocation {Id} on portfolio {PortfolioId} generated on {GeneratedOn}";
        }
    }
}



