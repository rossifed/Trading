using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Entities = Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories
{
    internal class BrokerSelectionRuleOverrideRepository : IBrokerSelectionRuleOverrideRepository
    {

        private IBrokerSelectionRuleOverrideDao BrokerSelectionRuleOverrideDao { get; }

        public BrokerSelectionRuleOverrideRepository(IBrokerSelectionRuleOverrideDao brokerSelectionRuleOverrideDao)
        {
            BrokerSelectionRuleOverrideDao = brokerSelectionRuleOverrideDao;
        }


       public async Task<IEnumerable<BrokerSelectionRuleOverride>> GetAllAsync()
        {
            IEnumerable<Entities.BrokerSelectionRuleOverride> entities = await BrokerSelectionRuleOverrideDao.GetAllAsync();
            return entities.Map();
       
        }

       
    }
}
