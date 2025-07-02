using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal class TradeModeSelector
    {
        private ISelectionRulePrioritization SelectionRulePrioritization { get; }
        public TradeModeSelector(IEnumerable<TradeModeSelectionRule> tradeModeSelectionRules)
        {
            TradeModeSelectionRules = tradeModeSelectionRules;
            SelectionRulePrioritization = new WeighedCriteriaPrioritization();
        }
   
       private IEnumerable<TradeModeSelectionRule> TradeModeSelectionRules { get; }
        internal TradeMode Select(BaseOrder order, Broker broker, bool isEfrp)
         => TradeModeSelectionRules
            .Where(rule => rule.IsSatisfied(order, broker, isEfrp))
            .OrderByDescending(x => x.GetPriority(SelectionRulePrioritization))
            .FirstOrDefault()
            ?.TradeMode
            ??TradeMode.STANDARD;

    }
}
