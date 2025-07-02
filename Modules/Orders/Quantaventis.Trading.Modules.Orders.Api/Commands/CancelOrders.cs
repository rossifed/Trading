using Quantaventis.Trading.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Api.Commands
{
    internal record CancelOrders(int RebalancingSessionId) : ICommand;
}
