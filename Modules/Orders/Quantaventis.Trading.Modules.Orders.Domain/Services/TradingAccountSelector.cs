using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal class TradingAccountSelector
    {
  
        public TradingAccountSelector(IEnumerable<TradingAccountSelectionRule> accountSelectionRules)
            
        {
            this.AccountSelectionRules = accountSelectionRules;
        }
        IEnumerable<TradingAccountSelectionRule> AccountSelectionRules { get; }
        internal TradingAccount Select(BaseOrder order, Broker broker, Model.TradeMode routingMethod)
        {
            TradingAccountSelectionRule? rule = AccountSelectionRules.Where(x => x.IsSatisfied(order, broker, routingMethod)).FirstOrDefault();

            if (rule == null)
                throw new InvalidOperationException($"No Trading Account found for the Order {order}");
            return rule.TradingAccount;

        }
    }
}
