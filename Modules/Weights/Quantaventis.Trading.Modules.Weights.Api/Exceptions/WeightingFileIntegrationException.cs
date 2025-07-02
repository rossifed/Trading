using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Weights.Api.Exceptions
{
    internal class WeightingFileIntegrationException :Exception
    {
        public WeightingFileIntegrationException(string message) :base(message)
        {
        }

    }
}
