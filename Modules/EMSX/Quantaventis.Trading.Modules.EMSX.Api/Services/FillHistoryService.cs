using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Api.Events.Out;
using Quantaventis.Trading.Modules.EMSX.Api.Options;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.History.Responses;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Services;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using System.Collections.Immutable;

namespace Quantaventis.Trading.Modules.EMSX.Api.Services
{
    internal interface IFillHistoryService
    {
        Task FetchFillsByDate(DateOnly date);
        Task<IEnumerable<EmsxFillDto>> GetFillsByOrderId(int orderId);
    }
    internal class FillHistoryService : IFillHistoryService
    {


        private IEmsxApiClientService EmsxApiClientService { get; }
        private ILogger<FillHistoryService> Logger { get; }
        private FillHistoryOptions FillHistoryOptions { get; }

        private IMessageBroker MessageBroker { get; }
        public FillHistoryService(

            FillHistoryOptions fillHistoryOptions,
            IEmsxApiClientService emsxApiClientService,
            IMessageBroker messageBroker,
            ILogger<FillHistoryService> logger)
        {
            FillHistoryOptions = fillHistoryOptions;
            EmsxApiClientService = emsxApiClientService;
            MessageBroker = messageBroker;
            Logger = logger;
        }
        public async Task<IEnumerable<EmsxFillDto>> GetFillsByOrderId(int orderId)
        {
            try
            {
                DateTime fromDateTime = DateOnly.FromDateTime(DateTime.Today).AddDays(-30).ToDateTime(TimeOnly.MinValue);//max history supported by emsx is 30 days
                DateTime toDateTime = DateOnly.FromDateTime(DateTime.Today).ToDateTime(TimeOnly.MaxValue);
                Filter filter = new OrdersFilter(orderId);
                GetFillsRequest getFillsRequest = new GetFillsRequest(fromDateTime, toDateTime, new UuidScope(FillHistoryOptions.Uuids), filter);


                HistoryResponse<GetFillsResponse> response = await EmsxApiClientService.SendRequestHistoryAsync<GetFillsRequest, GetFillsResponse>(getFillsRequest);
                IEnumerable<EmsxFillDto> dtos = response.PartialResponses.SelectMany(x => x.EmsxFills).ToList();

                return dtos;

            }
            catch (Exception ex)
            {

                Logger.LogError(ex, $"Error while retrieving fills for OrderId: {orderId}");
                throw;
            }


        }
        public async Task FetchFillsByDate(DateOnly date)
        {
            try
            {
                DateTime fromDateTime = date.ToDateTime(TimeOnly.MinValue);
                DateTime toDateTime = date.ToDateTime(TimeOnly.MaxValue);
                GetFillsRequest getFillsRequest = new GetFillsRequest(fromDateTime, toDateTime, new UuidScope(FillHistoryOptions.Uuids));

                HistoryResponse<GetFillsResponse> response = await EmsxApiClientService.SendRequestHistoryAsync<GetFillsRequest, GetFillsResponse>(getFillsRequest);
                IEnumerable<EmsxFillDto> dtos = response.PartialResponses.SelectMany(x => x.EmsxFills).ToList();

                ILookup<int, EmsxFillDto> fillsByOrderLookup = dtos.ToLookup(x => x.OrderId);
                foreach (var fillsByOrder in fillsByOrderLookup)
                {
                    var @event = new EmsxFillsFetched(fillsByOrder.Key, fillsByOrder.ToList());
                    await MessageBroker.PublishAsync(@event);
                }

            }
            catch (Exception ex)
            {

                Logger.LogError(ex, $"Error while retrieving fills for date: {date}");
                throw;
            }


        }
    }
}
