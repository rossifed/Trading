using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Events.Out;
using Quantaventis.Trading.Modules.EMSX.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;

namespace Quantaventis.Trading.Modules.EMSX.Api.ScheduledTasks
{
    internal class FetchFillsTask : IScheduledTask
    {
        private IFillHistoryService FillHistoryService { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<FetchFillsTask> Logger { get; }

        public FetchFillsTask(IFillHistoryService fillHistoryService,
            IMessageBroker messageBroker,
            ILogger<FetchFillsTask> logger)
        {
            FillHistoryService = fillHistoryService;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task ExecuteAsync()
        {
            Logger.LogWarning($"Scheduled Task {this} Triggered...");
            await FillHistoryService.FetchFillsByDate(DateOnly.FromDateTime(DateTime.UtcNow));
            Logger.LogWarning($"Scheduled Task {this} Terminated...");

        }
    }
}
