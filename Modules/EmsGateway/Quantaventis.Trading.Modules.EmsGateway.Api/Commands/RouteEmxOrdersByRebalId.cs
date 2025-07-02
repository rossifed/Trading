using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands.Handlers
{
    internal record RouteEmsxOrdersByRebalId(IEnumerable<string> OrderRefIds) : ICommand;

}
