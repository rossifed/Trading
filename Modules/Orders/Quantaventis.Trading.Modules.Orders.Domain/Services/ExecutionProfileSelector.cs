using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal class ExecutionProfileSelector
    {
       private ISelectionRulePrioritization SelectionRulePrioritization { get; }
        public ExecutionProfileSelector(IEnumerable<ExecutionProfileSelectionRule> executionProfileSelectionRules, 
            IEnumerable<ExecutionProfileSelectionRuleOverride> executionProfileSelectionRuleOverrides)
        {
            ExecutionProfileSelectionRules = executionProfileSelectionRules;
            SelectionRulePrioritization = new WeighedCriteriaPrioritization();// to be injected by IOC
            ExecutionProfileSelectionRuleOverrides = executionProfileSelectionRuleOverrides;
        }
        private IEnumerable<ExecutionProfileSelectionRuleOverride> ExecutionProfileSelectionRuleOverrides { get; }
        private IEnumerable<ExecutionProfileSelectionRule> ExecutionProfileSelectionRules { get; }
        internal ExecutionProfile Select(BaseOrder order, Broker broker, Model.TradeMode executionMethod)
        {

            ExecutionProfileSelectionRuleOverride? ruleOverride = ExecutionProfileSelectionRuleOverrides
                .Where(x => x.IsSatisfied(order.Portfolio, broker, order.Instrument, executionMethod)).SingleOrDefault();

            if (ruleOverride != null)
                return ruleOverride.ExecutionProfile;

            ExecutionProfileSelectionRule? rule = ExecutionProfileSelectionRules
                .Where(x => x.IsSatisfied(order.Portfolio, broker, order.Instrument,executionMethod))
                .OrderBy(x=>x.GetPriority(SelectionRulePrioritization))
                .FirstOrDefault();
                
            if (rule == null)           
                throw new InvalidOperationException($"No Execution Profile found for the Order {order}");
                return rule.ExecutionProfile;
           
        }
    }
}
