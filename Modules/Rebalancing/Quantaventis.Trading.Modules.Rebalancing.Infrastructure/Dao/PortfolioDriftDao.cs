using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao
{
    internal interface IPortfolioDriftDao
    {

        Task<IEnumerable<PortfolioDrift>> GetAllLastAsync();
        Task<PortfolioDrift?> GetLastByPortfolioIdAsync(byte portfolioId);
        Task CreateAsync(PortfolioDrift portfolioId);
        Task UpdateAsync(PortfolioDrift portfolioId);
    }

    internal class PortfolioDriftDao : IPortfolioDriftDao
    {
        private RebalancingDbContext DbContext { get; }

        public PortfolioDriftDao(RebalancingDbContext dbContext) {

            this.DbContext = dbContext;
        }


        public async Task<PortfolioDrift?> GetLastByPortfolioIdAsync(byte portfolioId)
        {

            return await DbContext.PortfolioDrifts
                 .AsNoTracking()
                 .Where(x => x.PortfolioId == portfolioId)
                 .Include(x => x.PositionDrifts)
                 .OrderByDescending(x => x.ComputedOn)
                 .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<PortfolioDrift>> GetAllLastAsync()
        {
            var drifts = await DbContext.PortfolioDrifts
                .AsNoTracking()
                .Include(x =>x.PositionDrifts)
                .GroupBy(pd => pd.PortfolioId)
                .Select(g => g.OrderByDescending(pd => pd.ComputedOn).FirstOrDefault())
                .ToListAsync();
            return drifts?? Enumerable.Empty<PortfolioDrift>();
        }
        public async Task CreateAsync(PortfolioDrift entity)
        {
           await DbContext.AddAsync(entity);
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(PortfolioDrift entity)
        {
             DbContext.Update(entity);
            await DbContext.SaveChangesAsync();
        }
    }

}
