using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class ExecutionAlgorithmParamSet
    {

        internal IEnumerable<(string Param, string Value)> Parameters { get; }


        internal ExecutionAlgorithmParamSet(IEnumerable<(string Param, string Value)> parameters)
        {
            Parameters = parameters;

        }


    }
}
