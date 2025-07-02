using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Execution.Api.Dto;
using Quantaventis.Trading.Modules.Execution.Api.Mappers;
using Quantaventis.Trading.Modules.Execution.Domain.Repositories;
using Quantaventis.Trading.Modules.Execution.Domain.Model;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Execution.Infrastructure.Dao;
namespace Quantaventis.Trading.Modules.Execution.Api.Services
{
    internal interface IEmsxOrderService
    {
        Task OnEmsxOrderCreatedAsync(EmsxOrderDto emsxOrderDto);
        Task OnEmsxOrderUpdatedAsync(EmsxOrderDto dto);

        Task OnEmsxOrderDeletedAsync(int orderId);

        Task OnEmsxOrderInitialPaintReceivedAsync(IEnumerable<EmsxOrderDto> emsxOrderDtos);

    }
    internal class EmsxOrderService : IEmsxOrderService
    {
        private IEmsxOrderExecutionService OrderExecutionService { get; }
        private IEmsxOrderRepository EmsxOrderRepository { get; }

        private ILogger<EmsxOrderService> Logger { get; }

        public EmsxOrderService(IEmsxOrderExecutionService orderExecutionService,
            IEmsxOrderRepository emsxOrderRepository,
            ILogger<EmsxOrderService> logger)
        {
            OrderExecutionService = orderExecutionService;
            EmsxOrderRepository = emsxOrderRepository;
            Logger = logger;
        }

        public async Task OnEmsxOrderDeletedAsync(int orderId)
        {
            Logger.LogInformation($"Order Expired Event received OrderId:{orderId}..");
            await Task.CompletedTask;

        }

        public async Task OnEmsxOrderCreatedAsync(EmsxOrderDto emsxOrderDto)
        {
            Logger.LogInformation($"Emsx Order Created Event received OrderId:{emsxOrderDto.Sequence}..");
            var emsxOrder = emsxOrderDto.Map();
            await EmsxOrderRepository.AddAsync(emsxOrder);
        }


        public async Task OnEmsxOrderUpdatedAsync(EmsxOrderDto emsxOrderDto)
        {
            

            var emsxOrder = emsxOrderDto.Map();
            Logger.LogInformation($"Order Updated Event received Order:{emsxOrder}..");
            if (string.IsNullOrEmpty(emsxOrderDto.Status))
            {
                Logger.LogInformation($"Received empty status for  OrderId:{emsxOrderDto.Sequence}");
            }
            else
            {
                var currentOrder = await EmsxOrderRepository.GetByOrderIdAsync(emsxOrderDto.Sequence);

                if (currentOrder != null)
                {
                    if (!currentOrder.IsExecuted)// we never update an executed order. Once executed it is in its final state.
                    {

                        var updatedOrder = currentOrder.UpdateFrom(emsxOrderDto.Map());
                        await EmsxOrderRepository.UpdateAsync(updatedOrder);
                        if (updatedOrder.IsExecuted)
                        {
                            Logger.LogInformation($"Order {emsxOrder} Executed..");
                            await OrderExecutionService.OnEmsxOrderExecuted(emsxOrder);

                        }
                    }
                }
                else
                {// the case we may have missed the order creation but then got an update event
                    await EmsxOrderRepository.AddAsync(emsxOrder);
                    if (emsxOrder.IsExecuted)
                    {
                        await OrderExecutionService.OnEmsxOrderExecuted(emsxOrder);

                    }
                }
            }
        }

        public async Task OnEmsxOrderInitialPaintReceivedAsync(IEnumerable<EmsxOrderDto> dtos)
        {
            Logger.LogInformation($"{dtos.Count()} Initial paint orders received..");
            foreach (var emsxOrder in dtos)
            {
                await OnEmsxOrderUpdatedAsync(emsxOrder);
            }
        }
    }
}
