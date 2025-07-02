using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface ITradeModeSelectionRuleDao
    {

        Task<IEnumerable<TradeModeSelectionRule>> GetAllAsync();

    }
    internal class TradeModeSelectionRuleDao : ITradeModeSelectionRuleDao
    {
        private OrdersDbContext DbContext { get; }

        public TradeModeSelectionRuleDao(OrdersDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<TradeModeSelectionRule>> GetAllAsync()
        {
            return await DbContext.TradeModeSelectionRules
                              .AsNoTracking()
                              .Include(x=>x.Broker)
                              .Include(x => x.Portfolio)
                              .Include(x=>x.InstrumentType)
                              .Include(x=>x.TradeMode)
                              .ToListAsync();
        }

   

    }
}
