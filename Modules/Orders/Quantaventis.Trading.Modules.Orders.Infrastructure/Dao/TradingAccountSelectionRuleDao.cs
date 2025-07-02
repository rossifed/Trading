using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface ITradingAccountSelectionRuleDao
    {

        Task<IEnumerable<TradingAccountSelectionRule>> GetAllAsync();

    }
    internal class TradingAccountSelectionRuleDao : ITradingAccountSelectionRuleDao
    {
        private OrdersDbContext DbContext { get; }

        public TradingAccountSelectionRuleDao(OrdersDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<TradingAccountSelectionRule>> GetAllAsync()
        {
            return await DbContext.TradingAccountSelectionRules
                              .AsNoTracking()
                              .Include(x => x.TradingAccount)
                              .Include(x => x.Portfolio)
                              .Include(x =>x.TradeMode)
                              .Include(x=>x.Broker)
                              .Include(x=>x.InstrumentType)
                              .ToListAsync();
        }
  

    }
}
