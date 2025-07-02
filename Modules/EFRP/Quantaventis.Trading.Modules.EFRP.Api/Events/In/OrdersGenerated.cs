using Quantaventis.Trading.Modules.EFRP.Api.Dto;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Api.Events.In
{
    internal record OrdersGenerated(int RebalancingSessionId, 
        DateOnly TradeDate, 
        string TradeMode, 
        string ExecutionChannel, 
        IEnumerable<OrderDto> Orders) : IEvent
    {
    }
}
