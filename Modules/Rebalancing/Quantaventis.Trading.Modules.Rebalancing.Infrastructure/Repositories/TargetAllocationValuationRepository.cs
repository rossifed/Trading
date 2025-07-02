using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao;

using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Repositories
{
    internal class TargetAllocationValuationRepository : ITargetAllocationValuationRepository
    {
        private ITargetAllocationValuationDao TargetAllocationValuationDao { get; }
        public TargetAllocationValuationRepository(ITargetAllocationValuationDao targetAllocationValuationDao)
        {
            TargetAllocationValuationDao = targetAllocationValuationDao;
        }

        public async Task<TargetAllocationValuation?> GetLastByPortfolioIdAsync(byte portfolioId)
        {
            var entity = await TargetAllocationValuationDao.GetLastByPortfolioIdAsync(portfolioId);
            return entity?.Map();
        }

        public async Task UpdateAsync(TargetAllocationValuation targetAllocationValuation)
        {
            var entity = targetAllocationValuation.Map();
            await TargetAllocationValuationDao.ReplaceAsync(entity);
        }

    }
}
