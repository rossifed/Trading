using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Rolling.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Rolling.Infrastructure.Dao
{
    internal interface IPositionDao
    {
        Task<IEnumerable<Position>> GetAllAsync();
        Task<IEnumerable<Position>> GetByPortfolioIdAsync(byte portoflioId);
    }
    internal class PositionDao : IPositionDao
    {
        private RollingDbContext DbContext { get; }

        public PositionDao(RollingDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            return await DbContext
                 .Positions
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<IEnumerable<Position>> GetByPortfolioIdAsync(byte portoflioId)
        {
            return await DbContext
               .Positions
               .AsNoTracking()
               .Where(x => x.PortfolioId == portoflioId)
               .ToListAsync();
        }
    }
}
