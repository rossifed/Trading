using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories
{
    internal class TargetAllocationRepository : ITargetAllocationRepository
    {
       private ITargetAllocationDao TargetAllocationDao { get; }
        public TargetAllocationRepository(ITargetAllocationDao targetAllocationDao)
        {
            this.TargetAllocationDao = targetAllocationDao;
        }

        public async Task<TargetAllocation?> GetLastByPortfolioIdAsync(byte portfolioId)
        {
           var entity = await TargetAllocationDao.GetLastByPortfolioIdAsync(portfolioId);
            return entity?.Map();
        }

        public async Task<IEnumerable<TargetAllocation>> GetAllAsync()
        {
            var entities = await TargetAllocationDao.GetAllAsync();
            return entities.Map();
        }
    }
}
