using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao
{
    internal interface IVwPositionDao
    {
        Task<IEnumerable<VwPosition>> GetByPortfolioIdAsync(byte portfolioId);
    }
    internal class VwPositionDao : IVwPositionDao
    {
        private PortfoliosDbContext DbContext { get; }

        public VwPositionDao(PortfoliosDbContext dbContext)
        {

            this.DbContext = dbContext;
        }



        public async Task<IEnumerable<VwPosition>> GetByPortfolioIdAsync(byte portfolioId)
        {
            return await DbContext.VwPositions
                .Where(x=>x.PortfolioId == portfolioId)
                   .AsNoTracking()
                   .ToListAsync();
        }

    
    }
}
