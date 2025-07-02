using Quantaventis.Trading.Modules.Risk.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Risk.Api.Events.In
{
    internal record RebalancingStarted(RebalancingSessionDto RebalancingSession) : IEvent
    {
    }
}
