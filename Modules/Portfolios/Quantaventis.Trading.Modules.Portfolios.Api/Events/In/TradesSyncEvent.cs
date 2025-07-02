using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Portfolios.Api.Events.In
{
    internal record TradesSyncEvent(IEnumerable<TradeDto> Trades) : IEvent
    {
    }

}
