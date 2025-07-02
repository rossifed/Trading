using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Mappers;
namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories
{
    internal class BrokerSelectionRuleRepository : IBrokerSelectionRuleRepository
    {

        private IBrokerSelectionRuleDao BrokerSelectionRuleDao { get; }

        public BrokerSelectionRuleRepository(IBrokerSelectionRuleDao bokerSelectionRuleDao)
        {
            BrokerSelectionRuleDao = bokerSelectionRuleDao;
        }


       public async Task<IEnumerable<BrokerSelectionRule>> GetAllAsync()
        {
            IEnumerable<Entities.BrokerSelectionRule> entities = await BrokerSelectionRuleDao.GetAllAsync();
            return entities.Map();
       
        }

       
    }
}
