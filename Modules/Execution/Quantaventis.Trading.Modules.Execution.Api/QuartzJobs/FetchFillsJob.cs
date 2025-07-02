using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Execution.Api.Commands.In;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Execution.Api.QuartzJobs
{
    [DisallowConcurrentExecution]
    internal class FetchFillsJob : IJob
    {

        private ILogger<FetchFillsJob> Logger { get; }
        private IMessageBroker MessageBroker { get; }

        public FetchFillsJob(
            IMessageBroker messageBroker,
            ILogger<FetchFillsJob> logger)
        {
            Logger = logger;
            MessageBroker = messageBroker;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var now = DateTime.Now;
            Logger.LogInformation($"FetchFillsJob executed at: {now}");
           await MessageBroker.PublishAsync(new FetchFillsByDate(DateOnly.FromDateTime(now)));
        }
    }
}
