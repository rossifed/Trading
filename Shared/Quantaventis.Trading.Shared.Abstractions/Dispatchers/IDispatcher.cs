using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Events;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Abstractions.Dispatchers
{
    public interface IDispatcher
    {

        Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : class, IEvent;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query, CancellationToken cancellationToken = default);
    }
}
