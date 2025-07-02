using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Dao
{
    internal interface IBrokerSelectionRuleDao
    {

        Task<IEnumerable<BrokerSelectionRule>> GetAllAsync();

    }
    internal class BrokerSelectionRuleDao : IBrokerSelectionRuleDao
    {
        private OrdersDbContext DbContext { get; }

        public BrokerSelectionRuleDao(OrdersDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<BrokerSelectionRule>> GetAllAsync()
        {
            return await DbContext.BrokerSelectionRules
                              .AsNoTracking()
                              .Include(x => x.Portfolio)
                              .Include(x=>x.Broker)
                              .Include(x=>x.InstrumentType)
                              .ToListAsync();
        }

   

    }
}
