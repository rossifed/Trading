using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Repositories
{
    internal interface ITradeStagingRepository
    {
        Task StageTradesAsync();
    }
    internal class TradeStagingRepository : ITradeStagingRepository
    {
        private TradesDbContext DbContext { get; }
    

        public TradeStagingRepository(TradesDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task StageTradesAsync()
        {
            await DbContext.Database.ExecuteSqlRawAsync("EXEC [trd].[spStageTrades]");
        }
   
    }
}
