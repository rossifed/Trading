using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Mappers;
using Entities = Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories
{
    internal class PortfolioRepository : IPortfolioRepository
    {
        private IPortfolioDao PortfolioDao { get; }
        public PortfolioRepository(IPortfolioDao portfolioDao)
        {
            this.PortfolioDao = portfolioDao;
        }
   

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            IEnumerable<Entities.Portfolio> entities = await PortfolioDao.GetAllAsync();
            return entities.Map();

        }
        public async Task UpdateAsync(Portfolio portfolio)
        {
            await PortfolioDao.UpdateAsync(portfolio.Map());

        }
        public async Task AddAsync(Portfolio portfolio)
        {
          await   PortfolioDao.CreateAsync(portfolio.Map());

        }
    }
}
