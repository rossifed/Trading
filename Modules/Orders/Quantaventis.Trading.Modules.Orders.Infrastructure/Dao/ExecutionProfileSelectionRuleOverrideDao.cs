using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface IExecutionProfileSelectionRuleOverrideDao
    {

        Task<IEnumerable<ExecutionProfileSelectionRuleOverride>> GetAllAsync();

    }
    internal class ExecutionProfileSelectionRuleOverrideDao : IExecutionProfileSelectionRuleOverrideDao
    {
        private OrdersDbContext DbContext { get; }

        public ExecutionProfileSelectionRuleOverrideDao(OrdersDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<ExecutionProfileSelectionRuleOverride>> GetAllAsync()
        {
            return await DbContext.ExecutionProfileSelectionRuleOverrides
                              .AsNoTracking()
                              .Include(x=>x.Broker)
                              .Include(x => x.Portfolio)
                              .Include(x=>x.Instrument)
                              .ThenInclude(x=>x.InstrumentType)
                              .Include(x => x.TradeMode)
                              .Include(x => x.ExecutionProfile)
                                .ThenInclude(x=>x.HandlingInstruction)
                              .Include(x => x.ExecutionProfile)
                                .ThenInclude(x => x.ExecutionChannel)
                              .Include(x => x.ExecutionProfile)
                                .ThenInclude(x => x.ExecutionAlgorithm)
                              .Include(x => x.ExecutionProfile)
                                .ThenInclude(x => x.OrderType)
                              .Include(x => x.ExecutionProfile)
                               .ThenInclude(x => x.TimeInForce)
                              .Include(x => x.ExecutionProfile)
                               .ThenInclude(x => x.ExecutionAlgorithmParamSet)
                              .Include(x => x.ExecutionProfile)
                               .ThenInclude(x => x.TradingDesk)
                              .ToListAsync();
        }

    }
}
