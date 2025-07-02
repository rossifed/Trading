using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Dao
{
    internal interface IFutureContractDao
    {
        Task<IEnumerable<FutureContract>> GetAllAsync();


    }
    internal class FutureContractDao : IFutureContractDao
    {
        private RollingDbContext DbContext { get; }

        public FutureContractDao(RollingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
    

        public async Task<FutureContract?> GetByIdAsync(int id)
        {
          return await  DbContext
                .FutureContracts
                .AsNoTracking()
                .Where(x => x.FutureContractId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FutureContract>> GetAllAsync()
        {
            return await DbContext
           .FutureContracts
           .AsNoTracking()
           .ToListAsync();
        }
    }
}
