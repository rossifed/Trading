using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using FlexLabs.EntityFrameworkCore.Upsert;
namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Dao
{
    internal interface IGenericFutureDao
    {
        Task<IEnumerable<GenericFuture>> GetAllAsync();

        Task SaveAsync(GenericFuture entity);

       
    }
    internal class GenericFutureDao : IGenericFutureDao
    {
        private EfrpDbContext DbContext { get; }

        public GenericFutureDao(EfrpDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

      

        public async Task SaveAsync(GenericFuture entity)
        {
           await DbContext.GenericFutures
                .Upsert(entity)
                .On(x=>x.GenericFutureId)
                .WhenMatched(x=>new GenericFuture() { 
                ContractSize = x.ContractSize,
                RootSymbol= x.RootSymbol,
                Symbol=x.Symbol
                })
                .RunAsync();
        }

        public async Task<IEnumerable<GenericFuture>> GetAllAsync()
        {
            return await DbContext.GenericFutures.AsNoTracking().ToListAsync();
        }
    }
}
