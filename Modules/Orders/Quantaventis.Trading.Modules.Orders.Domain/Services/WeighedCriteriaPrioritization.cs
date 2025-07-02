using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal class WeighedCriteriaPrioritization :ISelectionRulePrioritization
    {
        public int GetPriority(params object?[] criterias)
        {
            var weight = 0;
            var reversedCriterias = criterias.Reverse().ToArray();
            for (int i = 0; i < criterias.Count(); i++)
            {
                if (reversedCriterias[i] != null)
                {
                    weight += i;
                }
                else
                {
                    weight--;
                }
            }

            return weight;
        }
    }
}
