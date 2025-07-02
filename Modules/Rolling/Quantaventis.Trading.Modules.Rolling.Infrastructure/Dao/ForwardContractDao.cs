using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Dao
{
    internal interface IForwardContractDao
    {
        Task<IEnumerable<FxForward>> GetAllAsync();

    }
    internal class ForwardContractDao : IForwardContractDao
    {
        private RollingDbContext DbContext { get; }

        public ForwardContractDao(RollingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
   
        public async Task<IEnumerable<FxForward>> GetAllAsync()
        {
            return await DbContext
                       .FxForwards
                       .AsNoTracking()  
                       .ToListAsync();
        }
    }
}
