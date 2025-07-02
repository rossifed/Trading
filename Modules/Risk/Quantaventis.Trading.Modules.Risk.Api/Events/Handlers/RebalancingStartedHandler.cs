using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Risk.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Risk.Api.Events.In;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Dao;
using Entities = Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Risk.Api.Events;

namespace Quantaventis.Trading.Modules.Risk.Api.Commands.Handlers
{
    internal class RebalancingStartedHandler : IEventHandler<RebalancingStarted>
    {

        private IMessageBroker MessageBroker { get; }


        private ITargetAllocationCheckDao TargetAllocationCheckDao { get; }
        private ILogger<RebalancingStartedHandler> Logger { get; }
 

        public RebalancingStartedHandler(
            ITargetAllocationCheckDao targetAllocationCheckDao,
       
            IMessageBroker messageBroker,
            ILogger<RebalancingStartedHandler> logger)
        {

            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.TargetAllocationCheckDao = targetAllocationCheckDao;
            this.MessageBroker = messageBroker;
 
        }

     
        public async Task HandleAsync(RebalancingStarted @event, CancellationToken cancellationToken = default)
        {
            var rebalancingSessionDto = @event.RebalancingSession;
            List<TargetAllocationBreachDto> breachedAllocations = new List<TargetAllocationBreachDto>();
            //foreach (PortfolioDriftDto portfolioDriftDto in rebalancingSessionDto.PortfolioDrifts) { 
            //    var targetAllocationId = portfolioDriftDto.TargetAllocationId;
            //    var targetAllocationCheck = await TargetAllocationCheckDao.GetByTargetAllocationIdAsync(targetAllocationId);
            //    if (targetAllocationCheck == null)//should never happen
            //        throw new InvalidOperationException($"Target Allocation  {targetAllocationId} was not checked. Reblancing {rebalancingSessionDto.RebalancingSessionId} can't be validated");
            //    if (targetAllocationCheck.IsBreach)
            //        breachedAllocations.Add(new TargetAllocationBreachDto()
            //        {
            //            TargetAllocationCheckId = targetAllocationCheck.TargetAllocationCheckId,
            //            TargetAllocationId = targetAllocationCheck.TargetAllocationId,
            //            PortfolioId = portfolioDriftDto.PortfolioId
            //        });
            //}

            await MessageBroker.PublishAsync(new RiskPreTradeChecked(rebalancingSessionDto.RebalancingSessionId, breachedAllocations.Any()));
        }

    }

}
