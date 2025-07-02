using Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model
{
    internal class TargetAllocation
    {
        internal PortfolioId PortfolioId { get; }

        internal int Id { get; }
        internal IEnumerable<TargetWeight> TargetWeights { get; }

        internal TargetAllocation(int id, PortfolioId portfolioId, IEnumerable<TargetWeight> targetWeights)
        {
            Id = id;
            PortfolioId = portfolioId;
            TargetWeights = targetWeights;
        }

        internal TargetAllocationCheck Apply(IEnumerable<Constraint> constraints) {
            return new TargetAllocationCheck(this,constraints.Select(constraint => constraint.Check(TargetWeights)));
      
        }
    }
}
