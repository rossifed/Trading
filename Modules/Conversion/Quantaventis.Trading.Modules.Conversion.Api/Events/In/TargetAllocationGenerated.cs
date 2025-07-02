using Quantaventis.Trading.Modules.Conversion.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Out
{
    internal record TargetAllocationGenerated(
        byte PortfolioId, 
        int TargetAllocationId, 
        DateTime GeneratedOn, 
        IEnumerable<TargetWeightDto> TargetWeights) : IEvent
    {
    }
}
