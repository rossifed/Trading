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
    internal class PortfolioDriftRepository : IPortfolioDriftRepository
    {
        private IPortfolioDriftDao PortfolioDriftDao { get; }
        public PortfolioDriftRepository(IPortfolioDriftDao portfolioDriftDao)
        {
            PortfolioDriftDao = portfolioDriftDao;
        }

        public async Task<PortfolioDrift?> GetByPortfolioIdAsync(byte portfolioId)
        {
            var entity = await PortfolioDriftDao.GetLastByPortfolioIdAsync(portfolioId);
            return entity?.Map();
        }

        public async Task AddAsync(PortfolioDrift portfolioDrift)
        {
            await PortfolioDriftDao.CreateAsync(portfolioDrift.Map());
        }

        public async Task UpdateAsync(PortfolioDrift portfolioDrift)
        {
            await PortfolioDriftDao.UpdateAsync(portfolioDrift.Map());
        }

        public async Task<IEnumerable<PortfolioDrift>> GetAllLastAsync()
        {
            var entities = await PortfolioDriftDao.GetAllLastAsync();
            return entities.Map();
        }
    }
}
