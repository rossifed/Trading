using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface IExecutionProfileSelectionRuleDao
    {

        Task<IEnumerable<ExecutionProfileSelectionRule>> GetAllAsync();

    }
    internal class ExecutionProfileSelectionRuleDao : IExecutionProfileSelectionRuleDao
    {
        private OrdersDbContext DbContext { get; }

        public ExecutionProfileSelectionRuleDao(OrdersDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<ExecutionProfileSelectionRule>> GetAllAsync()
        {
            return await DbContext.ExecutionProfileSelectionRules
                              .AsNoTracking()
                              .Include(x=>x.Broker)
                              .Include(x => x.Portfolio)
                              .Include(x=>x.InstrumentType)
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
