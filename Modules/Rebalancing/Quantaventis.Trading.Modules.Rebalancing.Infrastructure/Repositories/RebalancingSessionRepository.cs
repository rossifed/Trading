using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao;

using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Mappers;


namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Repositories
{
    internal class RebalancingSessionRepository : IRebalancingSessionRepository
    {
        private IRebalancingSessionDao RebalancingSessionDao { get; }
        public RebalancingSessionRepository(IRebalancingSessionDao rebalancingSessionDao)
        {
            RebalancingSessionDao = rebalancingSessionDao;
        }

        public async Task<RebalancingSession?> GetByIdAsync(int rebalancingSessionId)
        {
          var entity =  await RebalancingSessionDao.GetByIdAsync(rebalancingSessionId);
            return entity?.Map(); 
        }
    

        public async Task<RebalancingSession> AddAsync(RebalancingSession rebalancingSession)
        {
            var id = await RebalancingSessionDao.CreateAsync(rebalancingSession.Map());
            var entity = await RebalancingSessionDao.GetByIdAsync(id);
            return entity.Map();
        }

        public async Task UpdateStatusAsync(RebalancingSession rebalancingSession)
        {
        
            await RebalancingSessionDao.UpdateStatusAsync(rebalancingSession.Map());

        }

        public async Task<bool> AnyRebalancingInProgress()
        {
          var inProgressRebals =   await RebalancingSessionDao.GetByStatusAsync(RebalancingStatus.InProgress().Label);
            return inProgressRebals.Any();
        }

        public async Task<RebalancingSession?> GetRebalancingInProgress()
        {
            var rebalEntity = await RebalancingSessionDao.GetByStatusAsync(RebalancingStatus.InProgress().Label);
            if (rebalEntity.Any())
              return await GetByIdAsync(rebalEntity.First().RebalancingSessionId);
            else
                return null;
        }
    }
}
