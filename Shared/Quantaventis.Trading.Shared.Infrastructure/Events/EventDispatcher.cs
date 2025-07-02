using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Microsoft.Extensions.DependencyInjection;
namespace Quantaventis.Trading.Shared.Infrastructure.Events
{
    internal sealed class EventDispatcher :IEventDispatcher
    {

        private readonly IServiceProvider ServiceProvider;

        public EventDispatcher(IServiceProvider serviceProvider) { 
        this.ServiceProvider = serviceProvider;
        }

       public async Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : class, IEvent
        {
            using var scope = ServiceProvider.CreateScope();
            var handlers = scope.ServiceProvider.GetServices<IEventHandler<TEvent>>();
            var tasks = handlers.Select(handler => handler.HandleAsync(@event, cancellationToken));
            await Task.WhenAll(tasks);
        }

      
    }
}
