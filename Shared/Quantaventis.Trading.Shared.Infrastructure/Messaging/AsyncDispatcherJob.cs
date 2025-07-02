using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Microsoft.Extensions.Logging;
namespace Quantaventis.Trading.Shared.Infrastructure.Messaging
{
    internal class AsyncDispatcherJob : BackgroundService
    {
        private IMessageChannel MessageChannel { get; }
        private IModuleClient ModuleClient { get; }
        private ILogger<AsyncDispatcherJob> Logger { get; }
        public AsyncDispatcherJob(IMessageChannel messageChannel, IModuleClient moduleClient, ILogger<AsyncDispatcherJob> logger)
        {
            this.MessageChannel = messageChannel;
            this.Logger = logger;
            this.ModuleClient = moduleClient;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var envelope in MessageChannel.Reader.ReadAllAsync(stoppingToken))
            {
                try
                {
                    await ModuleClient.PublishAsync(envelope.message, stoppingToken);
                }
                catch (Exception exception)
                {
                    Logger.LogError(exception, exception.Message);
                }

            }
        }
    }
}
