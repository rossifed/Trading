using Quantaventis.Trading.Modules.Orders.Api.Mappers;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
namespace Quantaventis.Trading.Modules.Orders.Api.Services
{
    internal interface IOrderRoutingService {

        Task RouteByRebalancingId(int rebalancingId);
    }
    internal class OrderRoutingService : IOrderRoutingService
    {
        private IOrderEventDispatcher OrdersDispatcher { get; }
        private IOrderRepository OrderRepository { get; }

        public OrderRoutingService(IOrderEventDispatcher ordersDispatcher, IOrderRepository orderRepository)
        {
            OrdersDispatcher = ordersDispatcher;
            OrderRepository = orderRepository;
        }

        public async Task RouteByRebalancingId(int rebalancingId)
        {
           IEnumerable<Order> orders = await OrderRepository.GetByRebalancingSessionId(rebalancingId);

           await OrdersDispatcher.DispatchOrdersRoutingRequest(orders.MapOrderRoutes());
        }

      
    }
}
