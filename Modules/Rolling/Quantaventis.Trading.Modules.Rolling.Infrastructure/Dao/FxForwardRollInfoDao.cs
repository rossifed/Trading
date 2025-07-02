using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Dao
{
    internal interface IFxForwardRollInfoDao
    {
        Task<IEnumerable<VwFxForwardRollInfo>> GetAllAsync();

    }
    internal class FxForwardRollInfoDao : IFxForwardRollInfoDao
    {
        private RollingDbContext DbContext { get; }

        public FxForwardRollInfoDao(RollingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
   
        public async Task<IEnumerable<VwFxForwardRollInfo>> GetAllAsync()
        {
            return await DbContext
                       .VwFxForwardRollInfos
                       .Where(x => x.NextContractId != null)
                       .AsNoTracking()  
                       .ToListAsync();
        }
    }
}
