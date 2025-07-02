using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Api.Events.Out;
using Quantaventis.Trading.Modules.Orders.Api.Mappers;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Orders.Api.Services
{
    internal interface IOrderEventDispatcher
    {
        Task DispatchOrdersRoutingRequest(IEnumerable<OrderRouteDto> routes);
        Task DispatchRebalancingOrdersGenerated(IEnumerable<OrderDto> orders);

        Task DispatchRollOrdersGenerated(IEnumerable<OrderDto> orders);
    }
    internal class OrderEventDispatcher : IOrderEventDispatcher
    {

        private IMessageBroker MessageBroker { get; }
        public OrderEventDispatcher(
            IMessageBroker messageBroker)
        {
            MessageBroker = messageBroker;

        }
        public async Task DispatchOrdersRoutingRequest(IEnumerable<OrderRouteDto> routes)
        {
            var groups = routes.GroupBy(x => (x.TradeMode, x.ExecutionChannel));
            foreach (var group in groups)
            {
                var key = group.Key;
                OrdersRoutingRequested ordersGeneratedEvent = new OrdersRoutingRequested( 
                    key.TradeMode,
                    key.ExecutionChannel,
                    group);

                await MessageBroker.PublishAsync(ordersGeneratedEvent);
            }
        }

        public async Task DispatchRebalancingOrdersGenerated(IEnumerable<OrderDto> orders)
        {
            var groups = orders.GroupBy(x => (x.RebalancingSessionId, x.TradeDate, x.TradeMode, x.ExecutionChannel));
            foreach (var group in groups)
            {
                var key = group.Key;
                OrdersGenerated ordersGeneratedEvent = new OrdersGenerated(key.RebalancingSessionId.Value,
                    key.TradeDate,
                    key.TradeMode,
                    key.ExecutionChannel,
                    group);

                await MessageBroker.PublishAsync(ordersGeneratedEvent);
            }
        }

        public async Task DispatchRollOrdersGenerated(IEnumerable<OrderDto> orders)
        {
            var groups = orders.GroupBy(x => ( x.TradeDate, x.TradeMode, x.ExecutionChannel));
            foreach (var group in groups)
            {
                var key = group.Key;
                RollOrdersGenerated ordersGeneratedEvent = new RollOrdersGenerated(
                    key.TradeDate,
                    key.TradeMode,
                    key.ExecutionChannel,
                    group);

                await MessageBroker.PublishAsync(ordersGeneratedEvent);
            }
        }
    }
}
