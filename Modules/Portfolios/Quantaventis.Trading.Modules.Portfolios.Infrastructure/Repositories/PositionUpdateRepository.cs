using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories
{
    internal interface IPositionUpdateRepository {
        Task ComputePositionsAll();

        Task ComputeMissingPositions();
        Task ComputePositions(byte daysBack);
        Task UpdatePositionsAsync();
        Task PropagateUpdatePositionsAsync();
    }
    internal class PositionUpdateRepository : IPositionUpdateRepository
    {
        private PortfoliosDbContext DbContext { get; }
        private IPositionDao PositionDao { get; }

        public PositionUpdateRepository(PortfoliosDbContext dbContext, IPositionDao positionDao)
        {
            DbContext = dbContext;
            PositionDao = positionDao;
        }

        public async Task UpdatePositionsAsync()
        {
           await PositionDao.UpdatePositionsAsync();
        }
        public async Task PropagateUpdatePositionsAsync()
        {
            await PositionDao.PropagateUpdatePositionsAsync();
        }

        public async Task ComputePositionsAll()
        {
            await PositionDao.ComputePositionsAll();
        }

        public async Task ComputePositions(byte daysBack)
        {
            await PositionDao.ComputePositions(daysBack);
        }

        public async Task ComputeMissingPositions()
        {
            await PositionDao.ComputeMissingPositions();
        }
    }
}
