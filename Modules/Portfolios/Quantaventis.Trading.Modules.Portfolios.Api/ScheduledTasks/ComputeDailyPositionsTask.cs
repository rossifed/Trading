using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.Out;
using Quantaventis.Trading.Modules.Portfolios.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;

namespace Quantaventis.Trading.Modules.Portfolios.Api.ScheduledTasks
{
    internal class ComputeDailyPositionsTask : IScheduledTask
    {
        private IPositionUpdateService PositionUpdateService { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<ComputeDailyPositionsTask> Logger { get; }

        public ComputeDailyPositionsTask(IPositionUpdateService positionUpdateService,
            IMessageBroker messageBroker,
            ILogger<ComputeDailyPositionsTask> logger)
        {
            PositionUpdateService = positionUpdateService;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task ExecuteAsync()
        {
            Logger.LogWarning($"Scheduled Task {this} Triggered...");
            await PositionUpdateService.ComputeDailyPositions();
            Logger.LogWarning($"Scheduled Task {this} Terminated...");
            await MessageBroker.PublishAsync(new DailyPositionsComputed());
        }
    }
}
