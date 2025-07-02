using Quantaventis.Trading.Modules.Rebalancing.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Options
{
    internal class RebalancingOptions 
    {

      public  string TradeDateSwitchTimeStr { get; set; }

      public TimeOnly TradeDateSwitchTime => TimeOnly.ParseExact(TradeDateSwitchTimeStr, "HH:mm");

    }
}
