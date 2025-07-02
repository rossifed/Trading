using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Subscriptions;
using System.Linq;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.Services
{
    public interface IEmsxService {
        void Reconnect();
        Task<CancelOrderResponse> CancelOrderAsync(int orderSequence);
        IEnumerable<EmsxOrder> GetAllOrders();
        Task<IEnumerable<EmsxOrder>> GetAllOrdersAsync();
        Task<CancelRouteResponse> CancelRouteAsync(int orderSequence, int routeId);
        Task<IEnumerable<CancelRouteResponse>> CancelRoutesAsync(IEnumerable<(int orderSequence, int routeId)> orderRoutes);
        Task<RouteOrderResponse> RouteOrderAsync(EmsxOrder emsxOrder);
        Task<RouteOrderResponse?> RouteOrderAsync(int sequence);
        Task<IEnumerable<RouteOrderResponse>> RouteOrdersAsync(IEnumerable<EmsxOrder> emsxOrders);
        Task<CancelOrderResponse> CancelBasketOrdersAsync(string basketName);
        Task<IEnumerable<RouteOrderResponse>> RouteBasketOrdersAsync(string basketName);
        Task<IEnumerable<string>> GetAllBasketsAsync();
        Task<IEnumerable<EmsxOrder>> GetFilledEmsxOrdersAsync(bool includePartialFill);
        Task<IEnumerable<EmsxOrder>> GetWorkingEmsxOrdersAsync();
        Task<IEnumerable<EmsxOrder>> GetCancelledEmsxOrdersAsync();
        Task<IEnumerable<EmsxOrder>> GetEmsxOrdersByRefIdAsync(IEnumerable<string> orderRefIds);
        IEnumerable<EmsxOrder> GetOrdersWhere(Func<EmsxOrder, bool> filterFunction);
        EmsxOrder? GetOrderWhere(Func<EmsxOrder, bool> filterFunction);
        Task<EmsxOrder?> GetOrderWhereAsync(Func<EmsxOrder, bool> filterFunction);
        Task<IEnumerable<EmsxOrder>> GetOrdersWhereAsync(Func<EmsxOrder, bool> whereFunction);
        CancelOrderResponse CancelOrders(IEnumerable<int> sequences);
        CancelOrderResponse CancelOrder(int sequence);
        Task<CancelOrderResponse> CancelOrdersAsync(IEnumerable<int> sequences);
        Task<IEnumerable<EmsxOrder>> GetOrdersByBasketAsync(string basketName);
        Task<EmsxOrder?> GetOrderByEmsxSequenceAsync(int sequence);
        Task<EmsxOrder?> GetOrderByOrderRefIdAsync(string orderRefId);
        Task<IEnumerable<EmsxOrder>> GetOrdersByStatusAsync(string status);
        Task<DeleteOrderResponse> DeleteOrderAsync(int sequence);
        DeleteOrderResponse DeleteOrders(IEnumerable<int> sequences);
        DeleteOrderResponse DeleteOrder(int sequence);
        Task<DeleteOrderResponse> DeleteOrdersAsync(IEnumerable<int> sequences);
        IEnumerable<CreateOrderResponse> CreateOrders(IEnumerable<EmsxOrder> orders);
        Task<IEnumerable<CreateOrderResponse>> CreateOrdersAsync(IEnumerable<EmsxOrder> orders);
        Task<CreateBasketResponse> CreateBasketAsync(string basketName, IEnumerable<int> sequences);
        CreateOrderResponse CreateOrder(EmsxOrder order);
        CreateOrderAndRouteResponse CreateOrderAndRoute(EmsxOrder order);
        Task<CreateOrderResponse> CreateOrderAsync(EmsxOrder order);
        Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest createOrderRequest);
        Task<CreateOrderAndRouteResponse> CreateOrderAndRouteAsync(EmsxOrder order);
        ModifyOrderResponse ModifyOrder(EmsxOrder order);
        Task<ModifyOrderResponse> ModifyOrderAsync(EmsxOrder order);
        Task<IEnumerable<EmsxOrder>> GetOrdersByRefIdAsync(IEnumerable<string> orderRefId);
        Task<IEnumerable<EmsxOrder>> GetOrdersByEmsxSequenceAsync(IEnumerable<int> sequences);
        Task<EmsxOrder?> GetOrderByRefIdAsync(string orderRefId);
    }
    internal class EmsxService : IEmsxService
    {
        private readonly object _lockObject = new object();
        private EmsxSession EmsxSession { get; set; }
        private IEmsxSessionFactory EmsxSessionFactory { get; }
        private ILogger<EmsxService> Logger { get; }
        public EmsxService(IEmsxSessionFactory emsxSessionFactory, ILogger<EmsxService> logger)
        {

            EmsxSessionFactory = emsxSessionFactory;
            EmsxSession = EmsxSessionFactory.CreateSession();
            Logger = logger;


        }

        public void Reconnect()
        {
            lock (_lockObject)
            {

                EmsxSession.Stop();
                EmsxSession = EmsxSessionFactory.CreateSession();
            }
        }

        public async Task<CancelOrderResponse> CancelOrderAsync(int orderSequence)
        {
            CancelOrderRequest cancelOrderReq = new CancelOrderRequest(orderSequence);
            return await EmsxSession.SendRequestAndGetResponseAsync(cancelOrderReq);
        }



        public IEnumerable<EmsxOrder> GetAllOrders()
        {

            OrderSubscriptionRequest orderSub = new OrderSubscriptionRequest();
            IEnumerable<OrderSubscriptionResponse> orderSubResponses = EmsxSession.SubscribeAndGetResponse<OrderSubscriptionResponse>(orderSub);
            return orderSubResponses.Select(x => x.Order).ToList();
        }
        public async Task<IEnumerable<EmsxOrder>> GetAllOrdersAsync()
        {

            OrderSubscriptionRequest orderSub = new OrderSubscriptionRequest();
            IEnumerable<OrderSubscriptionResponse> orderSubResponses = await EmsxSession.SubscribeAndGetResponseAsync<OrderSubscriptionResponse>(orderSub);
            return orderSubResponses.Select(x => x.Order);
        }
        public async Task<CancelRouteResponse> CancelRouteAsync(int orderSequence, int routeId)
        {
            CancelRouteRequest cancelRouteReq = new CancelRouteRequest(orderSequence, routeId);
            CancelRouteResponse cancelRouteResponse = await EmsxSession.SendRequestAndGetResponseAsync(cancelRouteReq);
            return cancelRouteResponse;

        }
        public async Task<IEnumerable<CancelRouteResponse>> CancelRoutesAsync(IEnumerable<(int orderSequence, int routeId)> orderRoutes)
        {
            List<CancelRouteResponse> cancelRouteResponses = new List<CancelRouteResponse>();
            foreach ((int orderSequence, int route) orderRoute in orderRoutes)
            {
                CancelRouteResponse response = await CancelRouteAsync(orderRoute.orderSequence, orderRoute.route);
                cancelRouteResponses.Add(response);
            }
            return cancelRouteResponses;
        }

        public async Task<RouteOrderResponse> RouteOrderAsync(EmsxOrder emsxOrder)
        {
      
            RouteOrderResponse routeOrderResponse = await EmsxSession.SendRequestAndGetResponseAsync(new RouteOrderRequest(emsxOrder));

            return routeOrderResponse;
        }
        public async Task<RouteOrderResponse?> RouteOrderAsync(int sequence)
        {
            EmsxOrder? emsxOrder = await GetOrderByEmsxSequenceAsync(sequence);
            if (emsxOrder != null)

                return await RouteOrderAsync(emsxOrder);
            return null;
        }
        public async Task<IEnumerable<RouteOrderResponse>> RouteOrdersAsync(IEnumerable<EmsxOrder> emsxOrders)
        {
            List<RouteOrderResponse> responses = new List<RouteOrderResponse>();
            foreach (EmsxOrder emsxOrder in emsxOrders.ToList())
            {
                try
                {
                    if (emsxOrder.IsRoutable)
                    {
                                RouteOrderResponse response = await RouteOrderAsync(emsxOrder);
                        responses.Add(response);
                    }
                }
                catch (EmsxApiException e)
                {
                    Logger.LogError(e, e.Message);


                }
            }
            return responses;
        }

        public async Task<CancelOrderResponse> CancelBasketOrdersAsync(string basketName)
        {
            IEnumerable<EmsxOrder> orders = await GetOrdersByBasketAsync(basketName);

            return await CancelOrdersAsync(orders.Select(x => x.Sequence).ToArray());
        }
        public async Task<IEnumerable<RouteOrderResponse>> RouteBasketOrdersAsync(string basketName)
        {
            IEnumerable<EmsxOrder> orders = await GetOrdersByBasketAsync(basketName);
            return await RouteOrdersAsync(orders);
        }
        public async Task<IEnumerable<string>> GetAllBasketsAsync()
        {
            IEnumerable<EmsxOrder> emsxOrders = await GetAllOrdersAsync();
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
            return emsxOrders
                .Where(x => x.BasketName != null)
                .Select(x => x.BasketName)
                .Distinct()
                .ToList();
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
        }



        public async Task<IEnumerable<EmsxOrder>> GetFilledEmsxOrdersAsync(bool includePartialFill)
        {
            return await GetOrdersWhereAsync(x => x.Status == OrderStatus.WORKING && (x.Status == OrderStatus.PARTFILLED && includePartialFill));
        }

        public async Task<IEnumerable<EmsxOrder>> GetWorkingEmsxOrdersAsync()
        {
            return await GetOrdersByStatusAsync(OrderStatus.WORKING);
        }

        public async Task<IEnumerable<EmsxOrder>> GetCancelledEmsxOrdersAsync()
        {
            return await GetOrdersByStatusAsync(OrderStatus.CANCEL);
        }

        public async Task<IEnumerable<EmsxOrder>> GetEmsxOrdersByRefIdAsync(IEnumerable<string> orderRefIds)
        {
            return await GetOrdersWhereAsync(x => orderRefIds.Contains(x.OrderRefId));
        }

        public IEnumerable<EmsxOrder> GetOrdersWhere(Func<EmsxOrder, bool> filterFunction)
        {
            OrderSubscriptionRequest orderSub = new OrderSubscriptionRequest();
            IEnumerable<OrderSubscriptionResponse> orderSubResponses = EmsxSession.SubscribeAndGetResponse<OrderSubscriptionResponse>(orderSub);
            return orderSubResponses.Select(x => x.Order).Where(x => filterFunction(x)).ToList();
        }
        public EmsxOrder? GetOrderWhere(Func<EmsxOrder, bool> filterFunction)
        {
            OrderSubscriptionRequest orderSub = new OrderSubscriptionRequest();
            IEnumerable<OrderSubscriptionResponse> orderSubResponses = EmsxSession.SubscribeAndGetResponse<OrderSubscriptionResponse>(orderSub);
            return orderSubResponses.Select(x => x.Order).FirstOrDefault(x => filterFunction(x));
        }

        public async Task<EmsxOrder?> GetOrderWhereAsync(Func<EmsxOrder, bool> filterFunction)
        {
            OrderSubscriptionRequest orderSub = new OrderSubscriptionRequest();
            IEnumerable<OrderSubscriptionResponse> orderSubResponses = await EmsxSession.SubscribeAndGetResponseAsync<OrderSubscriptionResponse>(orderSub);
            return orderSubResponses.Select(x => x.Order).FirstOrDefault(x => filterFunction(x));
        }

        public async Task<IEnumerable<EmsxOrder>> GetOrdersWhereAsync(Func<EmsxOrder, bool> whereFunction)
        {
            OrderSubscriptionRequest orderSub = new OrderSubscriptionRequest();
            IEnumerable<OrderSubscriptionResponse> orderSubResponses = await EmsxSession.SubscribeAndGetResponseAsync<OrderSubscriptionResponse>(orderSub);
            return orderSubResponses.Select(x => x.Order).Where(x => whereFunction(x)).ToList();
        }


        public CancelOrderResponse CancelOrders(IEnumerable<int> sequences)
        {

            CancelOrderRequest cancelOrderReq = new CancelOrderRequest(sequences);
            return EmsxSession.SendRequestAndGetResponse(cancelOrderReq);
        }

        public CancelOrderResponse CancelOrder(int sequence)
        {

            CancelOrderRequest cancelOrderReq = new CancelOrderRequest(sequence);
            return EmsxSession.SendRequestAndGetResponse(cancelOrderReq);
        }

        public async Task<CancelOrderResponse> CancelOrdersAsync(IEnumerable<int> sequences)
        {

            CancelOrderRequest cancelOrderReq = new CancelOrderRequest(sequences);
            return await EmsxSession.SendRequestAndGetResponseAsync(cancelOrderReq);
        }

        public async Task<IEnumerable<EmsxOrder>> GetOrdersByBasketAsync(string basketName)
        {

            return await GetOrdersWhereAsync(x => x.BasketName == basketName);
        }
        public async Task<EmsxOrder?> GetOrderByEmsxSequenceAsync(int sequence)
        {

            return await GetOrderWhereAsync(x => x.Sequence == sequence);
        }
        public async Task<EmsxOrder?> GetOrderByOrderRefIdAsync(string orderRefId)
        {
            OrderSubscriptionRequest orderSub = new OrderSubscriptionRequest();
            IEnumerable<OrderSubscriptionResponse> orderSubResponses = await EmsxSession.SubscribeAndGetResponseAsync<OrderSubscriptionResponse>(orderSub);
            return orderSubResponses.Select(x => x.Order).FirstOrDefault(x => x.OrderRefId == orderRefId);
        }
        public async Task<IEnumerable<EmsxOrder>> GetOrdersByStatusAsync(string status)
        {
            return await GetOrdersWhereAsync(order => order.Status?.ToUpper() == status.Trim().ToUpper());
        }



        public async Task<DeleteOrderResponse> DeleteOrderAsync(int sequence)
        {
            DeleteOrderRequest deleteOrderReq = new DeleteOrderRequest(sequence);
            return await EmsxSession.SendRequestAndGetResponseAsync<DeleteOrderResponse>(deleteOrderReq);
        }


        public DeleteOrderResponse DeleteOrders(IEnumerable<int> sequences)
        {

            DeleteOrderRequest deleteOrderReq = new DeleteOrderRequest(sequences);
            return EmsxSession.SendRequestAndGetResponse(deleteOrderReq);
        }

        public DeleteOrderResponse DeleteOrder(int sequence)
        {

            DeleteOrderRequest deleteOrderReq = new DeleteOrderRequest(sequence);
            return EmsxSession.SendRequestAndGetResponse(deleteOrderReq);
        }

        public async Task<DeleteOrderResponse> DeleteOrdersAsync(IEnumerable<int> sequences)
        {
            DeleteOrderRequest deleteOrderReq = new DeleteOrderRequest(sequences);
            return await EmsxSession.SendRequestAndGetResponseAsync<DeleteOrderResponse>(deleteOrderReq);
        }

        public IEnumerable<CreateOrderResponse> CreateOrders(IEnumerable<EmsxOrder> orders)
         => orders.Select(x => CreateOrder(x)).ToList();


        public async Task<IEnumerable<CreateOrderResponse>> CreateOrdersAsync(IEnumerable<EmsxOrder> orders)
        {
            List<CreateOrderResponse> createOrderResponses = new List<CreateOrderResponse>();
            foreach (EmsxOrder order in orders)
            {
                var createOrderResponse = await CreateOrderAsync(order);
                createOrderResponses.Add(createOrderResponse);
            }
            return createOrderResponses;
        }
        public async Task<CreateBasketResponse> CreateBasketAsync(string basketName, IEnumerable<int> sequences)
        {
            CreateBasketRequest createBasketRequest = new CreateBasketRequest(basketName, sequences);
            return await EmsxSession.SendRequestAndGetResponseAsync(createBasketRequest);
        }
        public CreateOrderResponse CreateOrder(EmsxOrder order)
        {
            CreateOrderRequest createOrderReq = new CreateOrderRequest(order);
            return EmsxSession.SendRequestAndGetResponse(createOrderReq);
        }
        public CreateOrderAndRouteResponse CreateOrderAndRoute(EmsxOrder order)
        {
            CreateOrderAndRouteRequest createOrderReq = new CreateOrderAndRouteRequest(order);
            return EmsxSession.SendRequestAndGetResponse(createOrderReq);
        }
        public async Task<CreateOrderResponse> CreateOrderAsync(EmsxOrder order)
        {
            CreateOrderRequest createOrderReq = new CreateOrderRequest(order);
            return await EmsxSession.SendRequestAndGetResponseAsync(createOrderReq);
        }
        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest createOrderRequest)
        {
            return await EmsxSession.SendRequestAndGetResponseAsync(createOrderRequest);
        }
        public async Task<CreateOrderAndRouteResponse> CreateOrderAndRouteAsync(EmsxOrder order)
        {
            CreateOrderAndRouteRequest createOrderReq = new CreateOrderAndRouteRequest(order);
            return await EmsxSession.SendRequestAndGetResponseAsync(createOrderReq);
        }
        public ModifyOrderResponse ModifyOrder(EmsxOrder order)
        {
            ModifyOrderRequest modifyOrderReq = new ModifyOrderRequest(order);
            return EmsxSession.SendRequestAndGetResponse(modifyOrderReq);
        }

        public async Task<ModifyOrderResponse> ModifyOrderAsync(EmsxOrder order)
        {
            ModifyOrderRequest modifyOrderReq = new ModifyOrderRequest(order);
            return await EmsxSession.SendRequestAndGetResponseAsync(modifyOrderReq);
        }

        public async Task<IEnumerable<EmsxOrder>> GetOrdersByRefIdAsync(IEnumerable<string> orderRefId)
        {
            return await GetOrdersWhereAsync(x => orderRefId.Contains(x.OrderRefId));
        }

        public async Task<IEnumerable<EmsxOrder>> GetOrdersByEmsxSequenceAsync(IEnumerable<int> sequences)
        {
            return await GetOrdersWhereAsync(x => sequences.Contains(x.Sequence));
        }

        public async Task<EmsxOrder?> GetOrderByRefIdAsync(string orderRefId)
        {
            return await GetOrderWhereAsync(x => x.OrderRefId == orderRefId);
        }
    }
}
