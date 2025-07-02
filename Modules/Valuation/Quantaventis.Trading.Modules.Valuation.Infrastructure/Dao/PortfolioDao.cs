using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Valuation.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Valuation.Infrastructure.Dao
{
    internal interface IPortfolioDao
    {
        Task<IEnumerable<Portfolio>> GetAllAsync();
        Task<Portfolio?> GetByIdAsync(byte portfolioId);
        Task UpdateAsync(Portfolio entity);

        Task ReplaceAsync(IEnumerable<Portfolio> entities);
        Task CreateAsync(Portfolio entity);

    }
    internal class PortfolioDao : IPortfolioDao
    {
        private ValuationDbContext DbContext { get; }

        public PortfolioDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
    

        public async Task CreateAsync(Portfolio entity)
        {
           await DbContext.AddAsync(entity);

           await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Portfolio entity)
        {
             DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
        }

        public async Task<Portfolio?> GetByIdAsync(byte portfolioId)
        {
           return await DbContext.Portfolios
                .Where(x => x.PortfolioId == portfolioId)
                .Include(x=>x.Positions)
                .ThenInclude(x=>x.Instrument)
                .ThenInclude(x=>x.FutureContract)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await DbContext.Portfolios
                .AsNoTracking()
              .Include(x => x.Positions)
              .ThenInclude(x => x.Instrument)
              .ThenInclude(x => x.FutureContract)
              .ToListAsync();
        }

        public async Task ReplaceAsync(IEnumerable<Portfolio> entities)
        {

            DbContext.Portfolios.RemoveRange(DbContext.Portfolios);
            await DbContext.AddRangeAsync(entities);

            await DbContext.SaveChangesAsync();
        }
    }
}
