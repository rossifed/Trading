using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Valuation.Domain.Repositories
{
    internal interface ITargetAllocationValuationRepository
    {
        Task<int> AddAsync(TargetAllocationValuation targetAllocationValuation);

      
    }
}
