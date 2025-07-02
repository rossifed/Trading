using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Repositories
{
    internal interface IBrokerSelectionRuleRepository
    {
        Task<IEnumerable<BrokerSelectionRule>> GetAllAsync();
    }
}
