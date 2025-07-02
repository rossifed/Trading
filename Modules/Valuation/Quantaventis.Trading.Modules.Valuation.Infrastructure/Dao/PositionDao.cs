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
    internal interface IPositionDao
    {

        Task UpdateAsync(Position entity);
        Task CreateAsync(Position entity);
        Task DeleteAsync(Position entity);

    }
    internal class PositionDao : IPositionDao
    {
        private ValuationDbContext DbContext { get; }

        public PositionDao(ValuationDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
    

        public async Task CreateAsync(Position entity)
        {
           await DbContext.AddAsync(entity);

           await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Position entity)
        {
             DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Position entity)
        {
            DbContext.Remove(entity);

            await DbContext.SaveChangesAsync();
        }

    }
}
