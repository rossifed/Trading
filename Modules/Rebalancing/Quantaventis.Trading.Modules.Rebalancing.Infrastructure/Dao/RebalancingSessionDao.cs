using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao
{
    internal interface IRebalancingSessionDao
    {
        Task<int> CreateAsync(Entities.RebalancingSession entity);
        Task UpdateStatusAsync(Entities.RebalancingSession entity);
        Task<Entities.RebalancingSession?> GetByIdAsync(int rebalancingSessionId);
        Task<IEnumerable<Entities.RebalancingSession>> GetByStatusAsync(string status);

    }

    internal class RebalancingSessionDao : IRebalancingSessionDao
    {
        private RebalancingDbContext DbContext { get; }

        public RebalancingSessionDao(RebalancingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<Entities.RebalancingSession?> GetByIdAsync(int rebalancingSessionId)
        {
            return await DbContext.RebalancingSessions
                .AsNoTracking()
                .Include(x => x.PortfolioDrifts)
                .ThenInclude(x => x.PositionDrifts)
                .Where(x => x.RebalancingSessionId == rebalancingSessionId)
                  .FirstOrDefaultAsync();

        }


        public async Task<int> CreateAsync(Entities.RebalancingSession entity)
        {
            entity.PortfolioDrifts.ToList().ForEach(x => DbContext.Attach(x));
            await DbContext.AddAsync(entity);


            await DbContext.SaveChangesAsync();
            return entity.RebalancingSessionId;
        }

        public async Task UpdateStatusAsync(Entities.RebalancingSession entity)
        {
            DbContext.RebalancingSessions.Attach(entity);

            DbContext.Entry(entity).Property(r => r.Status).IsModified = true;
            DbContext.Entry(entity).Property(r => r.StatusReason).IsModified = true;
            // Save changes to the database
            await DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<RebalancingSession>> GetByStatusAsync(string status)
        {
            return await DbContext.RebalancingSessions
                 .AsNoTracking()
                 .Where(x => x.Status == status)
                 .ToListAsync();
        }
    }

}
