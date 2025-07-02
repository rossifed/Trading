using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Queries.In
{
    internal record GetRebalancingSessionById(int RebalancingSessionId):IQuery<RebalancingSessionDto?>;
}
