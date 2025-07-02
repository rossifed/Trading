using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Execution.Api.Clients;
using Quantaventis.Trading.Modules.Execution.Api.Dto;
using Quantaventis.Trading.Modules.Execution.Api.Mappers;
using Quantaventis.Trading.Modules.Execution.Domain.Repositories;
using Quantaventis.Trading.Modules.Execution.Domain.Model;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Execution.Api.Events.Out;
using Quantaventis.Trading.Modules.Execution.Api.Options;
//using Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Execution.Api.Services
{
    internal interface IEmsxOrderExecutionService
    {
        Task OnEmsxOrderExecuted(EmsxOrder order);
        Task OnEmsxFillsReceived(int orderId, IEnumerable<EmsxFillDto> fillDtos);
     
    }
    internal class EmsxOrderExecutionService : IEmsxOrderExecutionService
    {
        private IEmsxOrderExecutionRepository EmsxOrderExecutionRepository { get; }

        private IEmsxFillDao EmsxFillDao { get; }
        private IEmsxClient EmsxClient { get; }

        private IMessageBroker MessageBroker { get; }
        private ILogger<EmsxOrderExecutionService> Logger { get; }
        private TimeOnly EodCutoffTimeUtc { get; }
        public EmsxOrderExecutionService(IEmsxOrderExecutionRepository orderExecutionRepository,
            IEmsxClient emsxClient,
            IEmsxFillDao emsxFillDao,
            IMessageBroker messageBroker,
            OrderExecutionOptions orderExecutionOptions,
            ILogger<EmsxOrderExecutionService> logger)
        {
            EmsxOrderExecutionRepository = orderExecutionRepository;
            EmsxClient = emsxClient;
            EmsxFillDao = emsxFillDao;
            MessageBroker = messageBroker;
            Logger = logger;
            EodCutoffTimeUtc = orderExecutionOptions.EodCutoffTimeUtc;
        }

      
        private bool IsAfterEndOfDayCutoff(DateTime dateTime) { 
            return  TimeOnly.FromDateTime(dateTime) >= EodCutoffTimeUtc;

        }
        public async Task OnEmsxOrderExecuted(EmsxOrder emsxOrder) {
            var orderId = emsxOrder.EmsxOrderId;
            IEnumerable<EmsxFillDto> fills = await EmsxClient.GetEmxFillsByOrderId(orderId);
            await OnEmsxFillsReceived(emsxOrder.EmsxOrderId, fills);
            
        }

  
        public async Task OnEmsxFillsReceived(int emsxOrderId, IEnumerable<EmsxFillDto> fillDtos)
        {
            Logger.LogInformation($"{fillDtos.Count()} emsx fills received..");
            await EmsxFillDao.UpsertAsync(fillDtos.Map());
            Domain.Model.EmsxTrade? orderExecution = await EmsxOrderExecutionRepository.GetByEmsxOrderIdAsync(emsxOrderId);
            if (orderExecution != null)
            {
                orderExecution.Validate();
                if (orderExecution.IsComplete() || IsAfterEndOfDayCutoff(DateTime.UtcNow))
                {
                    Logger.LogInformation($"OrderExecution {orderExecution} Completed");
                    await MessageBroker.PublishAsync(new EmsxTradeReceived(orderExecution.Map()));
                }

            }
            else {
                Logger.LogError($"An execepted order execution for the order {emsxOrderId} is missing");
            }
        }
    
    }
}
