using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses;
namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Services
{
    internal interface IEmsxApiClientService{
        Task ConnectAsync();
        Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest request) where TRequest:IRequest<TResponse>;
        Task<HistoryResponse<TResponse>> SendRequestHistoryAsync<TRequest, TResponse>(TRequest request) where TRequest : IHistoryRequest<TResponse>;
        void StartOrderSubscription(IOrderMessageHandler handler);
        void StopOrderSubscription();
        void StartRouteSubscription(IRouteMessageHandler handler);
        void StopRouteSubscription();
        Task<string> GetConnectionStatusAsync();
        void Disconnect();


    }
    internal  class EmsxApiClientService : IEmsxApiClientService
    {
        
        public IRequestResponseService RequestResponseService { get; }
        public IOrderSubscriptionService OrderSubscriptionService { get; }
        public IRouteSubscriptionService RouteSubscriptionService { get; }
        private ISessionManager SessionManager { get; }
        public IHistoryRequestService HistoryRequestService { get; }
        private ILogger<EmsxApiClientService> Logger { get; }
        private IEmsxEventHandler EmsxEventHandler { get; }
        public EmsxApiClientService(IRequestResponseService requestResponseService,
            IOrderSubscriptionService orderSubscriptionService,
            IRouteSubscriptionService routeSubscriptionService,
            IHistoryRequestService historyRequestService, 
            ISessionManager sessionManager,
            IEmsxEventHandler  emsxEventHandler,
            ILogger<EmsxApiClientService> logger)
        {
            RequestResponseService = requestResponseService;
            OrderSubscriptionService = orderSubscriptionService;
            RouteSubscriptionService = routeSubscriptionService;
            HistoryRequestService = historyRequestService;
            SessionManager = sessionManager;
            EmsxEventHandler = emsxEventHandler;
            Logger = logger;
          
        }


      
      
        public void Disconnect()
        {
            RouteSubscriptionService.CancelSubscription(SessionManager.GetOpenSession());
            OrderSubscriptionService.CancelSubscription(SessionManager.GetOpenSession());
            SessionManager
                .StopSession();
        }

    
        public async Task ConnectAsync() {
            try
            {
              var isstarted= await SessionManager
                    .StartSessionAsync(
                    EmsxEventHandler);
              
                Logger.LogInformation($"Emsx Session coonected {isstarted}");
            }
            catch (Exception e) {
                Logger.LogError(e, "Emsx Session connection error");
                throw ;
            }
        }

        public Task<TResponse> SendRequestAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
        {           
                return RequestResponseService
                .SendRequestAsync<TRequest, TResponse>(
                    request,
                    SessionManager.GetOpenSession());           
        }

        public void StartOrderSubscription(IOrderMessageHandler handler)
        {          
                OrderSubscriptionService
                .StartSubscription(
                    SessionManager.GetOpenSession(), handler);           
        }

        public void StopOrderSubscription()
        {       
                OrderSubscriptionService
                .CancelSubscription(
                    SessionManager.GetOpenSession());         
        }

        public void StartRouteSubscription(IRouteMessageHandler handler)
        {      
                RouteSubscriptionService
                .StartSubscription(
                    SessionManager.GetOpenSession(), 
                    handler);                    
        }

        public void StopRouteSubscription()
        {          
                RouteSubscriptionService
                .CancelSubscription(
                    SessionManager.GetOpenSession());                   
        }

        public Task<HistoryResponse<TResponse>> SendRequestHistoryAsync<TRequest, TResponse>(TRequest request) where TRequest : IHistoryRequest<TResponse>
        {
            return HistoryRequestService
                .SendRequestHistoryAsync<TRequest, TResponse>(
                request, 
                SessionManager.GetOpenSession());        
      
        }

        public Task<string> GetConnectionStatusAsync() {
            return Task.Run(() =>SessionManager.IsSessionOpen() ? "Open" : "Closed");
        }
    }
}
