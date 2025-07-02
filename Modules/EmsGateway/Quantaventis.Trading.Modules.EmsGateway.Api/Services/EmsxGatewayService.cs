using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Api.ACL;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Events.Out;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using System.Linq.Expressions;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Services
{
    internal interface IEmsxGatewayService
    {
        void ReconnectToEmsx();
        Task CancelEmsxOrderByRebalancingIdAsync(int rebalId);
        Task CancelEmsxOrderByRefIdAsync(string orderRefId);
        Task CancelEmsxOrdersByRefIdAsync(IEnumerable<string> orderRefIds);
        Task CreateEmsxOrdersAsync(IEnumerable<EmsxOrder> emsxOrders);

     //   Task RouteEmsxOrdersByRefIdAsync(IEnumerable<string> orderRefIds);
        Task RouteEmsxOrdersAsync(IEnumerable<EmsxOrder> emsxOrders);
        Task RouteEmsxOrdersAsync(IEnumerable<OrderRouteDto> emsxOrders);
        Task TriggerEmsxOrdersSyncEvent();

        Task<IEnumerable<EmsxOrder>> GetAllEmsxOrdersAsync();
        Task CreateBasketAsync(string basketName, IEnumerable<string> orderRefId);
        Task<EmsxOrder?> GetEmsxOrderByRefIdAsync(string orderRefId);
        Task<IEnumerable<string>> GetAllBasketsAsync();

        Task CancelBasketAsync(string basketName);

        Task DeleteBasketAsync(string basketName);

        Task<IEnumerable<EmsxOrder>> GetEmsxOrdersByBasketAsync(string basketName);

        Task<IEnumerable<EmsxOrder>> GetFilledEmsxOrdersAsync(bool includePartialFill);

        Task<IEnumerable<EmsxOrder>> GetWorkingEmsxOrdersAsync();

        Task<IEnumerable<EmsxOrder>> GetCancelledEmsxOrdersAsync();
        Task<IEnumerable<EmsxOrder>> GetEmsxOrdersByStatusAsync(string orderStatus);
        Task<IEnumerable<EmsxOrder>> GetEmsxOrdersByRefIdAsync(IEnumerable<string> orderRefIds);
        Task DeleteEmsxOrderAsync(string orderRefId);
      //  Task RouteBasketAsync(string basketName);
    }
    internal class EmsxGatewayService : IEmsxGatewayService
    {
        private IOrderToEmsxTranslator OrderTanslator { get; }
        private IEmsxService EmsxService { get; }
        private IBasketNameGenerator BasketNameGenerator { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<EmsxGatewayService> Logger { get; }
        public EmsxGatewayService(
            IOrderToEmsxTranslator orderTanslator,
            IBasketNameGenerator basketNameGenerator,
            IEmsxService emsxService,
            ILogger<EmsxGatewayService> looger,
            IMessageBroker messageBroker)
        {
            OrderTanslator = orderTanslator;
            BasketNameGenerator = basketNameGenerator;
            EmsxService = emsxService;
            MessageBroker = messageBroker;
            Logger = looger;
        }

        public async Task CancelEmsxOrdersByRefIdAsync(IEnumerable<string> orderRefIds)
        {
            Logger.LogInformation($"Cancelling EMSX Orders by RefId...");
            IEnumerable<EmsxOrder> emsxOrders = await EmsxService.GetOrdersByRefIdAsync(orderRefIds);
            IEnumerable<int> sequences = emsxOrders.Select(x => x.Sequence).ToList();
            await EmsxService.CancelOrdersAsync(sequences);
        }
        public async Task CancelEmsxOrderByRefIdAsync(string orderRefId)
        {
            await CancelEmsxOrdersByRefIdAsync(new List<string> { orderRefId });
        }
        public async Task CreateEmsxOrdersAsync(IEnumerable<EmsxOrder> emsxOrders)
        {
            Logger.LogInformation($"Creating EMSX Orders...");
            IEnumerable<CreateOrderResponse> orderCreationResponses = await EmsxService.CreateOrdersAsync(emsxOrders);
            Logger.LogInformation($"{emsxOrders.Count()} Created");
            int[] createdOrderSequences = orderCreationResponses.Select(x => x.EmsxSequence).ToArray();
            IEnumerable<EmsxOrder> createdOrders = await EmsxService.GetOrdersByEmsxSequenceAsync(createdOrderSequences);
            await MessageBroker.PublishAsync(new EmsxOrdersCreated(createdOrders.Map()));
        }

        public async Task RouteEmsxOrdersAsync(IEnumerable<EmsxOrder> emsxOrders)
        {
            try
            {
                Logger.LogInformation($"Routing {emsxOrders.Count()} Orders...");
                IEnumerable<RouteOrderResponse> responses = await EmsxService.RouteOrdersAsync(emsxOrders);
                IEnumerable<EmsxOrder> routedOrders = await EmsxService.GetOrdersByEmsxSequenceAsync(responses.Select(x => x.EmsxSequence).ToArray());
                await MessageBroker.PublishAsync(new EmsxOrdersRouted(routedOrders.Map()));// amybe we need to retreive per route id
            }
            catch (Exception e) {
                Logger.LogError(e.Message);
            }
            }

        public async Task RouteEmsxOrdersAsync(IEnumerable<OrderRouteDto> orderRouteDtos)
        {
            Logger.LogInformation($"Routing Orders...");
            IEnumerable<string> orderRefIds = orderRouteDtos.Select(x => x.OrderId.ToString());
            IEnumerable<EmsxOrder> emsxOrders = await EmsxService.GetEmsxOrdersByRefIdAsync(orderRefIds);
            IDictionary<string, OrderRouteDto> ordersDic = orderRouteDtos.ToDictionary(x => x.OrderId.ToString());
            foreach (EmsxOrder emsxOrder in emsxOrders) {
                OrderRouteDto orderRouteDto = ordersDic[emsxOrder.OrderRefId];
                emsxOrder.Strategy = orderRouteDto.ExecutionAlgorithm;
                emsxOrder.StrategyParameters = orderRouteDto.ExecutionAlgoParams.Map();
                
            }

            await RouteEmsxOrdersAsync(emsxOrders);
        }
        //public async Task RouteBasketAsync(string basketName)
        //{
        //    Logger.LogInformation($"Routing Basket {basketName}...");
        //    IEnumerable<EmsxOrder> emsxOrders = await GetEmsxOrdersByBasketAsync(basketName);
        //    await RouteEmsxOrdersAsync(emsxOrders);
        //}
        public async Task TriggerEmsxOrdersSyncEvent()
        {
            var timeStampUtc = DateTime.UtcNow;
            IEnumerable<EmsxOrder> orders = await EmsxService.GetAllOrdersAsync();           
            await MessageBroker.PublishAsync(new EmsxOrdersSyncEvent(orders.Map(), timeStampUtc));
            Logger.LogInformation($"EMSX Orders Sync Event Triggered at {timeStampUtc}. {orders.Count()} Orders found.");
        }
  
        public async Task<IEnumerable<EmsxOrder>> GetAllEmsxOrdersAsync()
        {
            return await EmsxService.GetAllOrdersAsync();
        }
        public async Task<IEnumerable<EmsxOrder>> GetEmsxOrdersByRefIdAsync(IEnumerable<string> orderRefIds)
        {
            return await EmsxService.GetOrdersByRefIdAsync(orderRefIds);
        }
        public async Task<EmsxOrder?> GetEmsxOrderByRefIdAsync(string orderRefId)
        {
            return await EmsxService.GetOrderByRefIdAsync(orderRefId);
        }
        public async Task<IEnumerable<string>> GetAllBasketsAsync()
        {
            return await EmsxService.GetAllBasketsAsync();
        }

        public async Task CancelBasketAsync(string basketName)
        {
            Logger.LogInformation($"Cancelling Basket {basketName}...");
            await EmsxService.CancelBasketOrdersAsync(basketName);
            IEnumerable<EmsxOrder> basketOrders = await EmsxService.GetOrdersByBasketAsync(basketName);
            await MessageBroker.PublishAsync(new EmsxBasketCancellationSent(basketName, basketOrders.Map()));
        }

        public async Task DeleteBasketAsync(string basketName)
        {
            Logger.LogInformation($"Deleting Basket {basketName}...");
            IEnumerable<EmsxOrder> emsxOrders = await GetEmsxOrdersByBasketAsync(basketName);
            await DeleteOrdersAsync(emsxOrders);
        }

        public async Task<IEnumerable<EmsxOrder>> GetEmsxOrdersByBasketAsync(string basketName)
        {
            return await EmsxService.GetOrdersByBasketAsync(basketName);

        }

        public async Task DeleteOrderAsync(string orderRefId)
        {
            Logger.LogInformation($"Deleting EMSX Orders {orderRefId}...");
            EmsxOrder? emsxOrder = await GetEmsxOrderByRefIdAsync(orderRefId);
            if (emsxOrder != null)
                await DeleteOrderAsync(emsxOrder);
        }
        public async Task DeleteOrdersAsync(IEnumerable<EmsxOrder> emsxOrders)
        {
            Logger.LogInformation($"Deleting EMSX Orders...");
            foreach (EmsxOrder emsxOrder in emsxOrders)
            {

                if (emsxOrder.Sequence != null)
                {
                    DeleteOrderResponse deleteOrderResponse = await EmsxService.DeleteOrderAsync(emsxOrder.Sequence);

                }
            }



        }
        public async Task DeleteOrderAsync(EmsxOrder emsxOrder)
        {
            Logger.LogInformation($"Deleting EMSX Order {emsxOrder.OrderRefId}...");
            if (emsxOrder != null && emsxOrder.Sequence != null)
            {

                await EmsxService.DeleteOrderAsync(emsxOrder.Sequence);
            }
        }

        public async Task CreateBasketAsync(string basketName, IEnumerable<string> orderRefIds)
        {
            IEnumerable<EmsxOrder> emsxOrders = await GetEmsxOrdersByRefIdAsync(orderRefIds);
            await EmsxService.CreateBasketAsync(basketName, emsxOrders.Select(x => x.Sequence));
            await MessageBroker.PublishAsync(new EmsxBasketCreated(basketName, emsxOrders.Map()));
        }

        public async Task DeleteEmsxOrderAsync(string orderRefId)
        {
            EmsxOrder? emsxOrder = await GetEmsxOrderByRefIdAsync(orderRefId);
            if (emsxOrder != null)
                await EmsxService.DeleteOrderAsync(emsxOrder.Sequence);
        }

        public async Task<IEnumerable<EmsxOrder>> GetFilledEmsxOrdersAsync(bool includePartialFill)
        {
            return await EmsxService.GetFilledEmsxOrdersAsync(includePartialFill);
        }

        public async Task<IEnumerable<EmsxOrder>> GetWorkingEmsxOrdersAsync()
        {
            return await EmsxService.GetWorkingEmsxOrdersAsync();
        }

        public async Task<IEnumerable<EmsxOrder>> GetCancelledEmsxOrdersAsync()
        {
            return await EmsxService.GetCancelledEmsxOrdersAsync();
        }

        public async Task<IEnumerable<EmsxOrder>> GetEmsxOrdersByStatusAsync(string orderStatus)
        {
            return await EmsxService.GetOrdersByStatusAsync(orderStatus);
        }

        public async Task CancelEmsxOrderByRebalancingIdAsync(int rebalId)
        {
       
           IEnumerable<EmsxOrder> ordersToCancel = await EmsxService.GetOrdersWhereAsync(x => x.CustomNote1 == rebalId.ToString());
            Logger.LogInformation($"Cancelling {ordersToCancel.Count()} EmsxOrders for RebalancingSession {rebalId}...");
            await EmsxService.CancelOrdersAsync(ordersToCancel.GetSequences());
            await MessageBroker.PublishAsync(new EmsxRebalCancellationSent(rebalId, ordersToCancel.GetOrderRefIds()));
        }

        public  void ReconnectToEmsx()
        {
            EmsxService.Reconnect();
        }
    }
}
