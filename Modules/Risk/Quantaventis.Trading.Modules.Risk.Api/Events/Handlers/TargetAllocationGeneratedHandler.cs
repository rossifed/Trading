using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Risk.Api.Events.Out;
using Quantaventis.Trading.Modules.Risk.Api.Mappers;
using Quantaventis.Trading.Modules.Risk.Api.Services;
using Quantaventis.Trading.Modules.Risk.Domain.Model;
using Quantaventis.Trading.Modules.Risk.Domain.Model.Constraints;
using Quantaventis.Trading.Modules.Risk.Domain.Repositories;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Quantaventis.Trading.Modules.Risk.Api.Events.Handlers
{
    internal class TargetAllocationGeneratedHandler : IEventHandler<TargetAllocationGenerated>
    {

        private ITargetAllocationCheckService TargetAllocationCheckService { get; }
        private IMessageBroker MessageBroker { get; }

        private ILogger<TargetAllocationGeneratedHandler> Logger { get; }
        public TargetAllocationGeneratedHandler(ITargetAllocationCheckService targetAllocationCheckService,
        IMessageBroker messageBroker,
            ILogger<TargetAllocationGeneratedHandler> logger) { 
            this.TargetAllocationCheckService = targetAllocationCheckService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;

        
        }
        public async Task HandleAsync(TargetAllocationGenerated @event, CancellationToken cancellationToken = default)
        {   var portfolioId = @event.PortfolioId;
            var targetAllocationId = @event.TargetAllocationId;
          
            TargetAllocation targetAllocation = new TargetAllocation(@event.TargetAllocationId, portfolioId, @event.TargetWeights.Map());
            await TargetAllocationCheckService.CheckConstraintsAsync(targetAllocation);

        }
    }
}
