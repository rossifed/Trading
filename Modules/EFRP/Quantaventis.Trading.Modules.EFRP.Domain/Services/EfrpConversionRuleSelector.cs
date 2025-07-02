using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
namespace Quantaventis.Trading.Modules.EFRP.Domain.Services
{
    internal interface IEfrpConversionRuleSelector {
        EfrpConversionRule? Select(FutureContract futureContract);


    }
    internal class EfrpConversionRuleSelector : IEfrpConversionRuleSelector
    { 
        private IEnumerable<EfrpConversionRule> EfrpConversionRules { get; }


        public EfrpConversionRuleSelector(IEnumerable<EfrpConversionRule> efrpConversionRules)
        {
            EfrpConversionRules = efrpConversionRules;
        }
        internal bool IsRuleEnabled(FutureContract futureContract)
        {
            EfrpConversionRule? rule = Select(futureContract);
            return rule == null ? false : rule.IsActive;
        }

        public EfrpConversionRule? Select(FutureContract futureContract) {
           return EfrpConversionRules
                .FirstOrDefault(rule => 
                rule.ApplyTo(futureContract) 
                && rule.IsActive);
        }

    }
}
