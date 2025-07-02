using Quantaventis.Trading.Modules.Valuation.Domain.Model;
using Quantaventis.Trading.Modules.Valuation.Domain.Repositories;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao;
using Entities = Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Valuation.Infrastructure.Mappers;

namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Repositories
{
    internal class PortfolioValuationRepository : IPortfolioValuationRepository
    {
       private IPortfolioValuationDao PortfolioValuationDao { get; }
        public PortfolioValuationRepository(IPortfolioValuationDao portfolioValuationDao)
        {
            this.PortfolioValuationDao = portfolioValuationDao;
        }

        public async Task<int> AddAsync(PortfolioValuation portfolioValuation)
        {
            var entity = portfolioValuation.Map();
            return await PortfolioValuationDao.CreateAsync(entity);

        }
        //public async Task<PortfolioValuation> GetLastByPortfolioIdAsync(int portfolioId)
        //{
        //    Entities.PortfolioValuation entity = await PortfolioValuationDao.GetLastByPortfolioIdAsync(portfolioId);

        //    if (entity == null)
        //        throw new Exception($"Not valuation has been found for portfolio {portfolioId}");

        //    return entity.Map();
        //}
    }
}
