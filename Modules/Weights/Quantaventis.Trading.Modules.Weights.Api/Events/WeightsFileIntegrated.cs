using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Events;

using Quantaventis.Trading.Modules.Weights.Api.Dto;
namespace Quantaventis.Trading.Modules.Weights.Api.Events
{
    internal record WeightsFileIntegrated(int modelWeightingId) : IEvent;

}
