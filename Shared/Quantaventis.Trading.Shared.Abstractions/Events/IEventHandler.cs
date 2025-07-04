using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Abstractions.Events
{
    public interface IEventHandler<in TEvent> where TEvent :class, IEvent
    {

        Task HandleAsync(TEvent @event, CancellationToken cancellationToken = default);
    }
}
