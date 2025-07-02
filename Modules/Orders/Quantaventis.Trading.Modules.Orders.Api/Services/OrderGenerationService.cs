using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Orders.Api.Events.Out;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Orders.Api.Mappers;
using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Api.ACL;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Quantaventis.Trading.Modules.Orders.Api.Services
{
    internal interface IOrderGenerationService {
      Task  GenerateOrdersAsync(int rebalancingId,DateOnly tradeDate, IEnumerable<BaseOrder> individualOrders);
      Task GenerateRollOrdersAsync(IEnumerable<BaseOrder> individualOrders);
    }
    internal class OrderGenerationService : IOrderGenerationService
    {
        private IOrderEventDispatcher OrdersDispatcher { get; }
        private IOrderEnrichmentService OrderEnrichmentService { get; }
        private IOrderRepository OrderRepository { get; }
        private ILogger<OrderGenerationService> Logger { get; }
        public OrderGenerationService(

            IOrderEnrichmentService orderEnrichmentService,
            IOrderRepository orderRepository,
            IOrderEventDispatcher ordersDispatcher,
            ILogger<OrderGenerationService> logger)
        {
            OrderEnrichmentService = orderEnrichmentService;
            OrdersDispatcher = ordersDispatcher;
            OrderRepository = orderRepository;
            Logger = logger;
        }
    
        public async Task GenerateOrdersAsync(int rebalancingSessionId,DateOnly tradeDate, IEnumerable<BaseOrder> baseOrders) {
            Logger.LogInformation($"Generating  Orders for Rebalancing  {rebalancingSessionId} with Trade Date{tradeDate}");
            IEnumerable<Order> enrichedOrders = await OrderEnrichmentService.EnrichOrdersAsync(baseOrders);  
           // IEnumerable<Order> aggregatedOrders = enrichedOrders.Aggregate();
            IEnumerable<Order> generatedOrders = await OrderRepository.ReplaceAsync(enrichedOrders);
    
            await OrdersDispatcher.DispatchRebalancingOrdersGenerated(generatedOrders.Map());

     
        }

        public async Task GenerateRollOrdersAsync(IEnumerable<BaseOrder> baseOrders)
        {
            Logger.LogInformation($"Generating Roll Orders");
            IEnumerable<Order> enrichedOrders = await OrderEnrichmentService.EnrichOrdersAsync(baseOrders);
          //  IEnumerable<Order> aggregatedOrders = enrichedOrders.Aggregate();
            IEnumerable<Order> generatedOrders = await OrderRepository.ReplaceAsync(enrichedOrders);

            await OrdersDispatcher.DispatchRollOrdersGenerated(generatedOrders.Map());
        }
    }
}
