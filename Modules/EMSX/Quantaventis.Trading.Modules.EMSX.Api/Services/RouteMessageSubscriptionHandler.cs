using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Events.Out;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Api.Services
{
    internal class RouteMessageSubscriptionHandler : IRouteMessageHandler
    {
        private IMessageBroker MessageBroker { get; }
        private ILogger<RouteMessageSubscriptionHandler> Logger { get; }

        public RouteMessageSubscriptionHandler(IMessageBroker messageBroker, ILogger<RouteMessageSubscriptionHandler> logger)
        {
            MessageBroker = messageBroker;
            Logger = logger;
        }



        public async Task OnInitialPaintEndAsync(IEnumerable<RouteSubscriptionMessage> initialPaintMessages)
        {
            Logger.LogInformation($"Initial Paint received with {initialPaintMessages.Count()} routes...");
            var routes = initialPaintMessages.Select(x => x.EmsxRoute).ToList();
            await MessageBroker.PublishAsync(new EmsxRoutesInitialPaintReceived(routes));
        }

        public async Task OnSubscriptionMessageAsync(RouteSubscriptionMessage message)
        {
            Logger.LogInformation($"Route message received {message.EmsxRoute.ToString()}");
            await MessageBroker.PublishAsync(new EmsxRouteEventReceived(message.EmsxRoute));
        }

        public async Task OnCreationEventAsync(RouteSubscriptionMessage message)
        {
            Logger.LogInformation($"Route Created  {message.EmsxRoute.ToString()}");
            await MessageBroker.PublishAsync(new EmsxRouteCreated(message.EmsxRoute));
        }

        public async Task OnDeletionEventAsync(RouteSubscriptionMessage message)
        {
            var sequence = message.EmsxRoute.Sequence;
            var routeId = message.EmsxRoute.RouteId;
            Logger.LogInformation($"Route Deleted Sequence:{sequence} RouteId:{routeId}");
            await MessageBroker.PublishAsync(new EmsxRouteDeleted(sequence,routeId));
        }

        public async Task OnUpdateEventAsync(RouteSubscriptionMessage message)
        {
            Logger.LogInformation($"Route Updated  {message.EmsxRoute.ToString()}");
            await MessageBroker.PublishAsync(new EmsxRouteUpdated(message.EmsxRoute));
        }
    }
}
