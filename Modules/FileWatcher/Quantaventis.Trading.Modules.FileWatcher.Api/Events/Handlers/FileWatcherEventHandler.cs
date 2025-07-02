using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Module.FileWatcher.Infrastructure.Events.Out;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Microsoft.Extensions.Logging;

namespace Quantaventis.Trading.Module.FileWatcher.Api.Events.Handlers
{
    internal class FileWatcherEventHandler : IEventHandler<FileWatcherEvent>
    {
       private IMessageBroker MessageBroker { get; }

        private ILogger<FileWatcherEvent> Logger { get; }

        public FileWatcherEventHandler(IMessageBroker messageBroker, ILogger<FileWatcherEvent> logger)
        {
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task HandleAsync(FileWatcherEvent @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Publishing the event {@event} to other modules");
           await  MessageBroker.PublishAsync( @event, cancellationToken );
        }
    }
}
