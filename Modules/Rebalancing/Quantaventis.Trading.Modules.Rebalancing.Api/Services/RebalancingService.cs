using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Dto;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Repositories;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.In;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events.Out;
using Quantaventis.Trading.Modules.Rebalancing.Api.Mappers;
using Quantaventis.Trading.Modules.Rebalancing.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.Rebalancing.Api.Events;
using Quantaventis.Trading.Modules.Rebalancing.Api.Options;
using Quantaventis.Trading.Modules.Rebalancing.Domain.Services;

namespace Quantaventis.Trading.Modules.Rebalancing.Api.Services
{
    internal interface IRebalancingService
    {
        Task StartRebalancingCancellation(int rebalancingId);
        Task ConfirmRebalancingCancelled(int rebalancingId);
        Task StartRebalancing();
    }
    internal class RebalancingService : IRebalancingService
    {


        private IPortfolioDriftRepository PortfolioDriftRepository { get; }
        private ILogger<RebalancingService> Logger { get; }
        private IRebalancingSessionRepository RebalancingSessionRepository { get; }

        private ITradeDateResolver TradeDateResolver { get; }
        private IMessageBroker MessageBroker { get; }

        private RebalancingOptions RebalancingOptions { get; }
        public RebalancingService(
            IRebalancingSessionRepository rebalancingSessionRepository,
            IPortfolioDriftRepository portfolioDriftRepository,
            ITradeDateResolver tradeDateResolver,
            RebalancingOptions rebalancingOptions,
            ILogger<RebalancingService> logger,
            IMessageBroker messageBroker)
        {
            RebalancingSessionRepository = rebalancingSessionRepository;
            PortfolioDriftRepository = portfolioDriftRepository;
            TradeDateResolver = tradeDateResolver;
            RebalancingOptions = rebalancingOptions;
            MessageBroker = messageBroker;
            Logger = logger;
        }

        public async Task StartRebalancingCancellation(int rebalancingId)
        {
            RebalancingSession? rebalancingSession = await RebalancingSessionRepository.GetByIdAsync(rebalancingId);
            if (rebalancingSession != null) {
                RebalancingSession? cancelledRebalancing = rebalancingSession.CancellationStarted();

                await RebalancingSessionRepository.UpdateStatusAsync(cancelledRebalancing);
                await MessageBroker.PublishAsync(new CancelRebalancingTriggered(rebalancingSession.Id));
            }
        }

        public async Task ConfirmRebalancingCancelled(int rebalancingId)
        {
            RebalancingSession? rebalancingSession = await RebalancingSessionRepository.GetByIdAsync(rebalancingId);
            if (rebalancingSession != null)
            {
                RebalancingSession? cancelledRebalancing = rebalancingSession.CancelLed();

                await RebalancingSessionRepository.UpdateStatusAsync(cancelledRebalancing);
                await MessageBroker.PublishAsync(new RebalancingCancelled(rebalancingSession.Id));
            }
        }

        public async Task OnTradesBooked(IEnumerable<TradeDto> tradeDtos){
            IEnumerable<int?> rebalancingIds = tradeDtos.Select(x => x.RebalancingId).Distinct();
            foreach (int? rebalancingId in rebalancingIds) { 
            
                if(rebalancingId != null)
                {
                 RebalancingSession? rebalancingSession =  await RebalancingSessionRepository.GetByIdAsync(rebalancingId.Value);
                    if (rebalancingSession == null) {
                        var errorMessage = $"RebalancingSession {rebalancingId} don't exists..";
                        Logger.LogError(errorMessage);
                        throw new InvalidOperationException(errorMessage);
                    }
                    RebalancingSession bookedRebalancing = rebalancingSession.TradesBooked();
                    await RebalancingSessionRepository.UpdateStatusAsync(bookedRebalancing);
                }
            }
        
        }

        public async Task StartRebalancing()
        {

          RebalancingSession? rebalInProgress = await  RebalancingSessionRepository.GetRebalancingInProgress();
            if (rebalInProgress != null)
            {
                throw new InvalidOperationException($"Rebalancing Can't be started because the rebalancing {rebalInProgress.Id} is already in progress.Ensure cancelling all the working orders prior cancelling the rebalancing");

            }
            else
            {
                IEnumerable<PortfolioDrift> portfolioDrifts = await PortfolioDriftRepository.GetAllLastAsync();

                DateOnly tradeDate = TradeDateResolver.NextTradeDate(RebalancingOptions.TradeDateSwitchTime, DateTime.UtcNow);
                RebalancingSession rebalancingSession = RebalancingSession.Start(portfolioDrifts, tradeDate);

                rebalancingSession = await RebalancingSessionRepository.AddAsync(rebalancingSession);


                var rebalancingDto = rebalancingSession.Map();


                await MessageBroker.PublishAsync(new RebalancingStarted(rebalancingSession.Map()));
            }
        }
    }
}
