using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal interface ISelectionRulePrioritization
    {
        public int GetPriority(params object?[] criterias);

    }
}
