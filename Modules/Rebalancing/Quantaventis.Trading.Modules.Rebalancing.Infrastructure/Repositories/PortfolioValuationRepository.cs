using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Dao;

using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Mappers;
using Entities = Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Repositories
{
    internal class PortfolioValuationRepository : IPortfolioValuationRepository
    {
        private IPortfolioValuationDao PortfolioValuationDao { get; }
        public PortfolioValuationRepository(IPortfolioValuationDao portfolioValuationDao)
        {
            PortfolioValuationDao = portfolioValuationDao;
        }

        public async Task<PortfolioValuation?> GetLastByPortfolioIdAsync(byte portfolioId)
        {
            var entity = await PortfolioValuationDao.GetLastByPortfolioIdAsync(portfolioId);
            return entity?.Map();
        }

        public async Task UpdateAsync(PortfolioValuation portfolioValuation)
        {
            var entity = portfolioValuation.Map();
            await PortfolioValuationDao.ReplaceAsync(entity);
        }
    }
}
