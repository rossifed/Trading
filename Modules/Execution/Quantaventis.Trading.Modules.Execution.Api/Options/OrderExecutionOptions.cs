using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Execution.Api.Options
{

    public class OrderExecutionOptions
    {
        public TimeOnly EodCutoffTimeUtc { get; set; }//The time after which we consider all the trade executed and accept partial trades.

     

    }
}
