using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Quantaventis.Trading.Shared.Abstractions.Contexts;

namespace Quantaventis.Trading.Modules.Rebalancing.Gui.Dao
{
    internal interface IRebalancingSessionDao
    {

        Task<RebalancingSession?> GetLastByPortfolioIdAsync(int portfolioId);
    }

    internal class RebalancingSessionDao : IRebalancingSessionDao
    {
        private RebalancingDbContext DbContext { get; }

        public RebalancingSessionDao(RebalancingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }


        public async Task<RebalancingSession?> GetByIdAsync(int rebalancingSessionId)
        {

            return await DbContext.RebalancingSessions
                 .AsNoTracking()
                 .Where(x => x.RebalancingSessionId == rebalancingSessionId)
                 .Include(x => x.PortfolioDrifts)
                 .ThenInclude(x => x.PositionDrifts)
                  .Include(x => x.PortfolioDrifts)
                  .ThenInclude(x => x.PortfolioValuation)
                  .ThenInclude(x => x.PositionValuations)
                  .Include(x => x.PortfolioDrifts)
                  .ThenInclude(x => x.TargetAllocationValuation)
                  .ThenInclude(x => x.TargetWeightValuations)
                 .FirstOrDefaultAsync();
        }

        public async Task<RebalancingSession?> GetLastByPortfolioIdAsync(int portfolioId)
        {
            var lastPortfolioDrift =await DbContext.PortfolioDrifts
          .Include(pd => pd.RebalancingSessions)
          .ThenInclude(x=>x.PortfolioDrifts)
          .ThenInclude(x=>x.PositionDrifts)
          .Include(pd => pd.RebalancingSessions)
          .ThenInclude(x => x.PortfolioDrifts)
          .ThenInclude(x=>x.PortfolioValuation)
          .Include(x=>x.PortfolioValuation)
          .Where(pd => pd.PortfolioValuation.PortfolioId == portfolioId)
          .OrderByDescending(pd => pd.ComputedOn)
          .FirstOrDefaultAsync();

            if (lastPortfolioDrift == null)
            {
                return null; // or throw an appropriate exception
            }

            // Get the last RebalancingSession associated with that PortfolioDrift
            var lastRebalancingSession = lastPortfolioDrift
  
                .RebalancingSessions
                
                    
                .OrderByDescending(rs => rs.StartedOn)
                .FirstOrDefault();

            return lastRebalancingSession;
        }
    }
}
