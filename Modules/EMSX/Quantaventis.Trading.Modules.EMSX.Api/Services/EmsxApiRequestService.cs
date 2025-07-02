using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Dto;
using Quantaventis.Trading.Modules.EMSX.Api.Mappers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Services;

namespace Quantaventis.Trading.Modules.EMSX.Api.Services
{

    internal interface IEmsxApiRequestService
    {
        Task AssignTraderAsync(int assigneeTraderUuid, IEnumerable<int> emsxSequences);
        Task CancelOrdersAsync(IEnumerable<int> emsxSequences);
        Task CancelRoutesAsync(IEnumerable<CancelRouteRequestDto> cancelRouteRequestDto);
        Task CreateBasketAsync(string basketName, IEnumerable<int> emsxSequences);

        Task CreateOrdersAsync(IEnumerable<CreateOrderRequestDto> createOrderRequestDtos);
        Task DeleteOrdersAsync(IEnumerable<int> emsxSequences);
        Task ModifyOrderAsync(ModifyOrderRequestDto modifyOrderRequestDto);
        Task RouteOrdersAsync(IEnumerable<RouteOrderRequestDto> routeOrderRequestDtos);
    }
    internal class EmsxApiRequestService : IEmsxApiRequestService
    {
        private IEmsxApiClientService EmsxApiClientService { get; }
        private ILogger<EmsxApiRequestService> Logger { get; }

        public EmsxApiRequestService(IEmsxApiClientService emsxApiClientService, ILogger<EmsxApiRequestService> logger)
        {
            EmsxApiClientService = emsxApiClientService;
            Logger = logger;
        }

        public async Task AssignTraderAsync(int assigneeTraderUuid, IEnumerable<int> emsxSequences)
        {

            Logger.LogInformation("Assign Trader Request Received...");
            AssignTraderRequest assignTraderRequest = new AssignTraderRequest(emsxSequences, assigneeTraderUuid);
            AssignTraderResponse response = await EmsxApiClientService.SendRequestAsync<AssignTraderRequest, AssignTraderResponse>(assignTraderRequest);
            Logger.LogInformation($"{response}");
        }

        public async Task CancelOrdersAsync(IEnumerable<int> emsxSequences)
        {
            Logger.LogInformation("Cancel Order Request Received...");
            CancelOrderRequest cancelorderRequest = new CancelOrderRequest(emsxSequences);
            CancelOrderResponse response = await EmsxApiClientService.SendRequestAsync<CancelOrderRequest, CancelOrderResponse>(cancelorderRequest);
            Logger.LogInformation($"{response}");


        }

        public async Task CancelRoutesAsync(IEnumerable<CancelRouteRequestDto> cancelRouteRequestDtos)
        {
            foreach (CancelRouteRequestDto cancelRouteRequestDto in cancelRouteRequestDtos)
            {
                await CancelRouteAsync(cancelRouteRequestDto.Sequence, cancelRouteRequestDto.RouteId);
            }
        }
        public async Task CancelRouteAsync(int emsxSequence, int routeId)
        {
            Logger.LogInformation("Cancel Route Request Received...");
            CancelRouteRequest cancelRouteRequest = new CancelRouteRequest(emsxSequence, routeId);
            CancelRouteResponse response = await EmsxApiClientService.SendRequestAsync<CancelRouteRequest, CancelRouteResponse>(cancelRouteRequest);
            Logger.LogInformation($"{response}");

        }
        public async Task CreateBasketAsync(string basketName, IEnumerable<int> emsxSequences)
        {
            Logger.LogInformation("Create Basket Request Received...");
            CreateBasketRequest createBasketRequest = new CreateBasketRequest(basketName, emsxSequences);
            CreateBasketResponse response = await EmsxApiClientService.SendRequestAsync<CreateBasketRequest, CreateBasketResponse>(createBasketRequest);
            Logger.LogInformation($"{response}");

        }
        public async Task CreateOrdersAsync(IEnumerable<CreateOrderRequestDto> createOrderRequestDtos)
        {
            foreach (CreateOrderRequestDto createOrderRequestDto in createOrderRequestDtos)
            {
                await CreateOrderAsync(createOrderRequestDto);
            }
        }
        public async Task CreateOrderAsync(CreateOrderRequestDto createOrderRequestDto)
        {
            Logger.LogInformation("Create Order Request Received...");
            CreateOrderRequest createOrderRequest = createOrderRequestDto.Map();
            CreateOrderResponse response = await EmsxApiClientService.SendRequestAsync<CreateOrderRequest, CreateOrderResponse>(createOrderRequest);
            Logger.LogInformation($"{response}");
   
        }
        public async Task DeleteOrdersAsync(IEnumerable<int> emsxSequences)
        {
            Logger.LogInformation("Delete Order Request Received...");
            DeleteOrderRequest routeOrderRequest = new DeleteOrderRequest(emsxSequences);
            DeleteOrderResponse response = await EmsxApiClientService.SendRequestAsync<DeleteOrderRequest, DeleteOrderResponse>(routeOrderRequest);
            Logger.LogInformation($"{response}");

        }
        public async Task ModifyOrderAsync(ModifyOrderRequestDto modifyOrderRequestDto)
        {
            Logger.LogInformation("Modify Order Request Received...");
            ModifyOrderRequest modifyOrderRequest = modifyOrderRequestDto.Map();
            ModifyOrderResponse response = await EmsxApiClientService.SendRequestAsync<ModifyOrderRequest, ModifyOrderResponse>(modifyOrderRequest);
            Logger.LogInformation($"{response}");  
        }

        public async Task RouteOrdersAsync(IEnumerable<RouteOrderRequestDto> routeOrderRequestDtos)
        {
            foreach (RouteOrderRequestDto orderRequestDto in routeOrderRequestDtos)
            {
                await RouteOrderAsync(orderRequestDto);
            }
        }
        private async Task RouteOrderAsync(RouteOrderRequestDto routeOrderRequestDto)
        {
            Logger.LogInformation("Route Order Request Received...");
            RouteOrderRequest routeOrderRequest = routeOrderRequestDto.Map();
            RouteOrderResponse response = await EmsxApiClientService.SendRequestAsync<RouteOrderRequest, RouteOrderResponse>(routeOrderRequest);
            Logger.LogInformation($"{response}");

        }
    }
}
