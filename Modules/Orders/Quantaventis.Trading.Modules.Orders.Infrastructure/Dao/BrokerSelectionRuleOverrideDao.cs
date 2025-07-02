using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface IBrokerSelectionRuleOverrideDao
    {

        Task<IEnumerable<BrokerSelectionRuleOverride>> GetAllAsync();

    }
    internal class BrokerSelectionRuleOverrideDao : IBrokerSelectionRuleOverrideDao
    {
        private OrdersDbContext DbContext { get; }

        public BrokerSelectionRuleOverrideDao(OrdersDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<BrokerSelectionRuleOverride>> GetAllAsync()
        {
            return await DbContext.BrokerSelectionRuleOverrides
                              .AsNoTracking()
                              .Include(x => x.Portfolio)
                              .Include(x=>x.Broker)
                              .Include(x=>x.Instrument)
                              .ThenInclude(x=>x.InstrumentType)
                              .ToListAsync();
        }

   

    }
}
