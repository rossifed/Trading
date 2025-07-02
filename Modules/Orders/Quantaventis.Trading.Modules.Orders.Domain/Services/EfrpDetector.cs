using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal class EfrpDetector
    {
        private IEnumerable<EfrpSelectionRule> EfrpSelectionRules { get; }
  
        public EfrpDetector(IEnumerable<EfrpSelectionRule> efrpSelectionRules
            )
        {
            EfrpSelectionRules = efrpSelectionRules;
        }
        internal bool IsEfrp(BaseOrder order, Broker broker)
          => EfrpSelectionRules
            .Where(rule => rule.IsSatisfied(order, broker))
            .FirstOrDefault()
            ?.IsEfrp
            ?? false;

    }
}
