using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Shared.Abstractions.Contexts;

namespace Quantaventis.Trading.Modules.Valuation.Gui.Dao
{
    internal interface ITargetAllocationValuationDao {

        Task<TargetAllocationValuation?> GetLastByPortfolioIdAsync(byte portfolioId);
    }
    internal class TargetAllocationValuationDao : ITargetAllocationValuationDao
    {
        private readonly ValuationDbContext DbContext;

        public TargetAllocationValuationDao(ValuationDbContext context)
        {
            DbContext = context;
        }

        public async Task<TargetAllocationValuation?> GetLastByPortfolioIdAsync(byte portfolioId)
        {
            return await DbContext.TargetAllocationValuations
                  .AsNoTracking()
                  .Include(tav => tav.TargetWeightValuations)
                  .ThenInclude(x =>x.Instrument)
                  .Where(tav => tav.TargetAllocation.PortfolioId == portfolioId)
                  .OrderByDescending(tav => tav.TargetAllocationValuationId)
                  .FirstOrDefaultAsync();
        }
    }
}
