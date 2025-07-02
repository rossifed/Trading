using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories
{
    internal interface ITargetAllocationValuationRepository
    {

        Task<TargetAllocationValuation?> GetLastByPortfolioIdAsync(byte portfolioId);
        Task UpdateAsync(TargetAllocationValuation targetAllocationValuation);
    }
}
