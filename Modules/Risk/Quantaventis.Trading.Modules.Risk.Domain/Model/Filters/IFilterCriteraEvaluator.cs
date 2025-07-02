using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Domain.Model.Filters
{
    internal interface IFilterCriteriaEvaluation<T>
    {
        bool Evaluate(T t);
    }
}
