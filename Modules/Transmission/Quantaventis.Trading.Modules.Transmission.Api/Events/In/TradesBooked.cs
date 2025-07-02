using Quantaventis.Trading.Modules.Transmission.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Api.Events.In
{
    internal record TradesBooked(IEnumerable<TradeDto> Trades) : IEvent
    {
    }

}
