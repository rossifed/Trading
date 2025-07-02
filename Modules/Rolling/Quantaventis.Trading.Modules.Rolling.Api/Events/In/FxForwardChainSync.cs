using Quantaventis.Trading.Modules.Rolling.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Rolling.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Rolling.Api.Events.In
{
    internal record FxForwardChainSync(CurrencyPairDto CurrencyPair,IEnumerable<FxForwardDto> FxForwards ) : IEvent;

}
