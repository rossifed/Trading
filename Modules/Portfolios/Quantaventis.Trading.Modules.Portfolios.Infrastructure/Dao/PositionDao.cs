using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using System.Data;
namespace Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao
{
    internal interface IPositionDao
    {
        Task ComputeMissingPositions();
        Task ComputePositionsAll();
        Task ComputePositions(byte daysBack);

        Task UpdatePositionsAsync();
        Task PropagateUpdatePositionsAsync();


    }
    internal class PositionDao : IPositionDao
    {
        private PortfoliosDbContext DbContext { get; }

        public PositionDao(PortfoliosDbContext dbContext)
        {

            this.DbContext = dbContext;
        }


        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            return await DbContext.Portfolios
                       .AsNoTracking()
                       .ToListAsync();
        }

        public async Task ComputePositionsAll()
        {
            await DbContext.Database.ExecuteSqlRawAsync("EXEC port.spTestComputePositionsAll");
        }

        public async Task ComputePositions(byte daysBack)
        {
            var param = new SqlParameter("@DaysBack", daysBack);
          

            await DbContext.Database.ExecuteSqlRawAsync("EXEC port.spTestComputePositions @DaysBack", param);

        }


        public async Task UpdatePositionsAsync()
        {
            var sql = "EXEC [port].[spUpdatePositions]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }
        public async Task PropagateUpdatePositionsAsync()
        {
            var sql = "EXEC [port].[spPropagateUpdatePositions]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }

        public async Task ComputeMissingPositions()
        {
            var sql = "EXEC [port].[spComputeMissingPositions]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }
    }
}
