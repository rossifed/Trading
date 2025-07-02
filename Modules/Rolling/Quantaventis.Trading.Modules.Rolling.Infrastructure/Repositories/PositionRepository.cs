using Quantaventis.Trading.Modules.Rolling.Domain.Model;
using Quantaventis.Trading.Modules.Rolling.Domain.Repositories;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Repositories
{
    internal class PositionRepository : IPositionRepository
    {
        private IPositionDao PositionDao { get; }

        public PositionRepository(IPositionDao positionDao)
        {
            PositionDao = positionDao;
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            var entities = await PositionDao.GetAllAsync();
            return entities.Map();
        }

        public async Task<IEnumerable<Position>> GetByPortfolioIdAsync(byte portfolioId)
        {
            var entities = await PositionDao.GetByPortfolioIdAsync(portfolioId);
            return entities.Map();
        }
    }
}
