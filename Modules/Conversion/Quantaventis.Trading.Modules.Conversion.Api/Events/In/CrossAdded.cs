using Quantaventis.Trading.Modules.Conversion.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Conversion.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Out
{
    internal record CurrencyPairAdded(CurrencyPairDto CurrencyPair, CurrencyPairDto InverseCurrencyPair) : IEvent;

}
