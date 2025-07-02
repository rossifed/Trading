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
    internal interface IFutureContractDao
    {
        Task<IEnumerable<FutureContract>> GetAllAsync();
        Task<IEnumerable<FutureContract>> GetByIdsAsync(IEnumerable<int> ids);
        Task SaveAsync(FutureContract entity);
        Task SaveRangeAsync(IEnumerable<FutureContract> entity);

    }
    internal class FutureContractDao : IFutureContractDao
    {
        private EfrpDbContext DbContext { get; }

        public FutureContractDao(EfrpDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public Task<IEnumerable<FutureContract>> GetById(int genericFutureId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(FutureContract entity)
        {
           await DbContext
                .Upsert(entity)
                .On(x=>x.FutureContractId)
                .WhenMatched(x=>new FutureContract() { 
                    Symbol = x.Symbol,
                LastTradeDate= x.LastTradeDate,
                })
                .RunAsync();
        }

        public async Task<IEnumerable<FutureContract>> GetAllAsync()
        {
            return await DbContext
                .FutureContracts
                .AsNoTracking()
                .Include(x=>x.GenericFuture)
                .ToListAsync();
        }

        public async Task SaveRangeAsync(IEnumerable<FutureContract> entities)
        {
            await DbContext.FutureContracts
                     .UpsertRange(entities)
                     .On(x => x.FutureContractId)
                     .WhenMatched(x => new FutureContract()
                     {
                         Symbol = x.Symbol,
                         LastTradeDate = x.LastTradeDate,
                     })
                     .RunAsync();
        }

        public async Task<IEnumerable<FutureContract>> GetByIdsAsync(IEnumerable<int> ids)
        {
            return await DbContext
              .FutureContracts
              .AsNoTracking()
              .Where(x=>ids.Contains(x.FutureContractId))
              .Include(x => x.GenericFuture)
              .ToListAsync();
        }
    }
}
