using Quantaventis.Trading.Modules.Conversion.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;

namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Out
{
    internal record CfdAdded(CfdDto Cfd) : IEvent;


}
