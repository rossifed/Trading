using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Events.In
{
    internal record EfrpOrdersFlagged(int RebalancingSessionId,IEnumerable<BaseOrderDto> BaseOrders) : IEvent
    {
    }
}
