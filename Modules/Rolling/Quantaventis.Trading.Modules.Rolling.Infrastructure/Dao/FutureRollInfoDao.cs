using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Dao
{
    internal interface IFutureRollInfoDao
    {
        Task<IEnumerable<VwFutureContractRollInfo>> GetAllAsync();

    }
    internal class FutureRollInfoDao : IFutureRollInfoDao
    {
        private RollingDbContext DbContext { get; }

        public FutureRollInfoDao(RollingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
   
        public async Task<IEnumerable<VwFutureContractRollInfo>> GetAllAsync()
        {
            return await DbContext
                       .VwFutureContractRollInfos
                       .Where(x=>x.NextContractId != null)
                       .AsNoTracking()  
                       .ToListAsync();
        }
    }
}
