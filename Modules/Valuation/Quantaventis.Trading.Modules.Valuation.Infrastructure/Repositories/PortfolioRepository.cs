using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories
{
    internal class PortfolioRepository : IPortfolioRepository
    {
       private IPortfolioDao PortfolioDao { get; }
        public PortfolioRepository(IPortfolioDao portfolioDao)
        {
            this.PortfolioDao = portfolioDao;
        }

        public async Task<Portfolio?> GetByIdAsync(byte portfolioId)
        {
            var entity = await PortfolioDao.GetByIdAsync(portfolioId);
            return entity?.Map();
        }

        public async Task<Money> GetPortfolioValueAsync(byte portfolioId)
        {
            var entity = await PortfolioDao.GetByIdAsync(portfolioId);
            return new Money(entity.TotalValue, entity.Currency);
        }

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            var entity = await PortfolioDao.GetAllAsync();
            return entity.Map();
        }
    }
}
