using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Booking.Api.Events.In;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Modules.Booking.Api.Mappers;
using System.Linq;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;

namespace Quantaventis.Trading.Modules.Booking.Api.Events.Handlers
{
    internal class OrdersGeneratedHandler : IEventHandler<OrdersGenerated>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<OrdersGeneratedHandler> Logger { get; }
        private IOrderRepository OrderRepository { get;}

        public OrdersGeneratedHandler(
             IOrderRepository orderRepository,
            ILogger<OrdersGeneratedHandler> logger)              
        {
            OrderRepository = orderRepository;
        
            this.Logger = logger;

        }

     
        public async Task HandleAsync(OrdersGenerated @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"OrdersGenerated event with {@event.Orders.Count()} orders received...");
            var entities = @event.Orders.Map();
           await OrderRepository.UpsertRangeAsync(entities);

        }

    }

}
