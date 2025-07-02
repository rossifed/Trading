using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Services;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions.Handlers;

namespace Quantaventis.Trading.Modules.EMSX.Api.Services
{
    interface IEmsxSessionHostedService : IHostedService
    {
        
    }
    internal class EmsxSessionHostedService : IEmsxSessionHostedService
    {

        private IEmsxApiClientService EmsxApiClientService { get; }
        private ILogger<EmsxSessionHostedService> Logger { get; }

        private IOrderMessageHandler OrderMessageHandler { get; }
        private IRouteMessageHandler RouteMessageHandler { get; }
        public EmsxSessionHostedService
            (IEmsxApiClientService emsxApiClientService,
            IOrderMessageHandler orderMessageHandler,
            IRouteMessageHandler routeMessageHandler,
            ILogger<EmsxSessionHostedService> logger)
        {
            EmsxApiClientService = emsxApiClientService;
            OrderMessageHandler = orderMessageHandler;
            RouteMessageHandler = routeMessageHandler;
            Logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Starting Emsx Hosted Service...");
            try
            {
                await EmsxApiClientService.ConnectAsync();
                EmsxApiClientService.StartOrderSubscription(OrderMessageHandler);
                //  EmsxApiClientService.StartRouteSubscription(RouteMessageHandler);
            } catch (Exception ex)
            {
                Logger.LogError(ex.Message);

            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("Stopping Emsx Hosted Service...");
            EmsxApiClientService.Disconnect();
          
        }

      
 
    }
}
