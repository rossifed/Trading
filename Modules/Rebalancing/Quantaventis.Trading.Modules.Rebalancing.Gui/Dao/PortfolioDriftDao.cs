using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
namespace Quantaventis.Trading.Modules.Rebalancing.Gui.Dao
{
    internal interface IPortfolioDriftDao
    {

        Task<PortfolioDrift?> GetLastByPortfolioIdAsync(byte portfolioId);

    }
    internal class PortfolioDriftDao : IPortfolioDriftDao
    {
        private RebalancingDbContext DbContext { get; }

        public PortfolioDriftDao(RebalancingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }


        public async Task<PortfolioDrift?> GetLastByPortfolioIdAsync(byte portfolioId)
        {

            return await DbContext.PortfolioDrifts
                 .AsNoTracking()
                 .Where(x => x.PortfolioValuation.PortfolioId == portfolioId)
                 .Include(x => x.PositionDrifts)
                 .Include(x => x.PortfolioValuation)
                 .Include(x => x.TargetAllocationValuation)
                 .OrderByDescending(x => x.ComputedOn)
                 .FirstOrDefaultAsync();
        }
 
  
    }
}
