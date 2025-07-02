using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal class BrokerSelector
    {
        private ISelectionRulePrioritization SelectionRulePrioritization { get; }
        private IEnumerable<BrokerSelectionRule> BrokerSelectionRules { get; }
        private IEnumerable<BrokerSelectionRuleOverride> BrokerSelectionRuleOverrides { get; }
        public BrokerSelector(IEnumerable<BrokerSelectionRule> brokerSelectionRules, IEnumerable<BrokerSelectionRuleOverride> brokerSelectionRuleOverrides)
        {
            BrokerSelectionRules = brokerSelectionRules;
            BrokerSelectionRuleOverrides = brokerSelectionRuleOverrides;
            SelectionRulePrioritization = new WeighedCriteriaPrioritization();
        }
   
  
        internal Broker Select(BaseOrder order)
        {
          BrokerSelectionRuleOverride? ruleOverride =  BrokerSelectionRuleOverrides.Where(x => x.IsSatisfied(order.Portfolio, order.Instrument)).SingleOrDefault();

            if (ruleOverride != null)
                return ruleOverride.Broker;
            
            BrokerSelectionRule? brokerRule = BrokerSelectionRules
                .Where(x => x.IsSatisfied(order.Portfolio, order.Instrument))
                 .OrderByDescending(x => x.GetPriority(SelectionRulePrioritization))
                .FirstOrDefault();
           
            if (brokerRule == null)
                throw new InvalidOperationException($"No Broker found for the Order {order}");
            return brokerRule.Broker;

        }
    }
}
