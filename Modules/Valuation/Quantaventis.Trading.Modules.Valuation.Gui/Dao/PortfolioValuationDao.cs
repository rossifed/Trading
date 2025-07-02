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
    internal interface IPortfolioValuationDao {

        Task<PortfolioValuation?> GetLastByPortfolioIdAsync(byte portfolioId);
    }
    internal class PortfolioValuationDao : IPortfolioValuationDao
    {
        private readonly ValuationDbContext DbContext;

        public PortfolioValuationDao(ValuationDbContext context)
        {
            DbContext = context;
        }

        public async Task<PortfolioValuation?> GetLastByPortfolioIdAsync(byte portfolioId)
        {
            return await DbContext.PortfolioValuations
                  .AsNoTracking()
                  .Include(tav => tav.PositionValuations)
                  .ThenInclude(x =>x.Instrument)
                  .Where(tav => tav.PortfolioId == portfolioId)
                  .OrderByDescending(tav => tav.PortfolioValuationId)
                  .FirstOrDefaultAsync();
        }
    }
}
