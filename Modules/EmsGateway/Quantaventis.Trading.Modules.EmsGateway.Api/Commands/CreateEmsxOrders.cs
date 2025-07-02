using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Commands
{
    internal record CreateEmsxOrder(IEnumerable<OrderDto> Orders) :ICommand;
}
