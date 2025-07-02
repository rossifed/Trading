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
    internal class AccountSelectionRuleRepository : IAccountSelectionRuleRepository
    {

        private ITradingAccountSelectionRuleDao TradingAccountSelectionRuleDao { get; }

        public AccountSelectionRuleRepository(ITradingAccountSelectionRuleDao tradingAccountSelectionRuleDao)
        {
            TradingAccountSelectionRuleDao = tradingAccountSelectionRuleDao;
        }


       public async Task<IEnumerable<TradingAccountSelectionRule>> GetAllAsync()
        {
            IEnumerable<Entities.TradingAccountSelectionRule> entities = await TradingAccountSelectionRuleDao.GetAllAsync();
            IEnumerable<TradingAccountSelectionRule> accountSelectionRule = entities.Map();
            return accountSelectionRule;
        }

 
    }
}
