using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface IExchangeDao
    {
        Task<IEnumerable<Exchange>> GetAllAsync();
        Task<Exchange> SaveAsync(Exchange entity);

    }
    internal class ExchangeDao : IExchangeDao
    {
        private InstrumentsDbContext DbContext { get; }

        public ExchangeDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }


        public async Task<IEnumerable<Exchange>> GetAllAsync()
        {
            return await DbContext.Exchanges
                .AsNoTracking()
                    .ToListAsync();
        }

        public async Task<Exchange> SaveAsync(Exchange entity)
        {
            if (entity.ExchangeId <= 0)
                await DbContext.AddAsync(entity);
            else
                DbContext.Update(entity);

            await DbContext.SaveChangesAsync();
            return entity;
        }
    }
}
