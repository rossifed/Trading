using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.EFRP.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.EFRP.Api.Events.In
{
    internal record FutureContractAdded(FutureContractDto FutureContract, GenericFutureDto GenericFuture) : IEvent;

}
