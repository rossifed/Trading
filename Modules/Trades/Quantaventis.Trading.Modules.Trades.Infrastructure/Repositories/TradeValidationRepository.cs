using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Trades.Infrastructure.Repositories
{
    internal interface ITradeValidationRepository {

        Task ValidateTradesAsync();
    }

    internal class TradeValidationRepository : ITradeValidationRepository
    {
        private TradesDbContext DbContext { get; }

        public TradeValidationRepository(TradesDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task ValidateTradesAsync()
        {
            var sql = "EXEC [trd].[spValidateTradesToBook]";
            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }
    }
}
