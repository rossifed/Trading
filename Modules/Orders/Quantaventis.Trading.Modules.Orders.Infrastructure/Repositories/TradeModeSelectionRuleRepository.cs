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
using System.Security.Cryptography.X509Certificates;

namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Repositories
{
    internal class TradeModeSelectionRuleRepository : ITradeModeSelectionRuleRepository
    {

        private ITradeModeSelectionRuleDao TradeModeSelectionRuleDao { get; }

        public TradeModeSelectionRuleRepository(ITradeModeSelectionRuleDao tradeModeSelectionRuleDao)
        {
            TradeModeSelectionRuleDao = tradeModeSelectionRuleDao;
        }


       public async Task<IEnumerable<TradeModeSelectionRule>> GetAllAsync()
        {
            IEnumerable<Entities.TradeModeSelectionRule> entities = await TradeModeSelectionRuleDao.GetAllAsync();
            return entities.Map();
 
        }

    } 
}
