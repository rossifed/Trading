using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Shared.Abstractions.Contexts;

namespace Quantaventis.Trading.Modules.Rebalancing.Gui.Dao
{
    internal interface IPortfolioDao {

        Task<IEnumerable<Portfolio>> GetAllAsync();
    }
    internal class PortfolioDao : IPortfolioDao
    {
        private readonly PortfoliosDbContext DbContext;

        public PortfolioDao(PortfoliosDbContext context)
        {
            DbContext = context;
        }

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await DbContext
                .Portfolios
                .OrderBy(x=>x.PortfolioId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
