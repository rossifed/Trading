using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories
{
    internal class TargetAllocationValuationRepository : ITargetAllocationValuationRepository
    {
       private ITargetAllocationValuationDao TargetAllocationValuationDao { get; }
        public TargetAllocationValuationRepository(ITargetAllocationValuationDao targetAllocationValuationDao)
        {
            this.TargetAllocationValuationDao = targetAllocationValuationDao;
        }

        public async Task<int> AddAsync(TargetAllocationValuation targetAllocationValuation)
        {
            var entity = targetAllocationValuation.Map();
            return await TargetAllocationValuationDao.CreateAsync(entity);
      
        }
    }
}
