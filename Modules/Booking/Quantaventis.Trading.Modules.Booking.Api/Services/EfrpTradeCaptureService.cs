using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Api.Dto;
using Quantaventis.Trading.Modules.Booking.Api.Mappers;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;

namespace Quantaventis.Trading.Modules.Booking.Api.Services
{
    internal interface IEfrpTradeCaptureService
    {
        Task<RawTrade> CaptureTradeAsync(byte portfolioId, EfrpTradeDto efrpTradeDto);
    }
    internal class EfrpTradeCaptureService : IEfrpTradeCaptureService
    {

        private IRawTradeRepository RawTradeRepository { get; }
        private IOrderRepository OrderRepository { get; }
        private ILogger<EmsxTradeCaptureService> Logger { get; }

        public EfrpTradeCaptureService(IRawTradeRepository rawTradeRepository, IOrderRepository orderRepository, ILogger<EmsxTradeCaptureService> logger)
        {
            RawTradeRepository = rawTradeRepository;
            OrderRepository = orderRepository;
            Logger = logger;
        }

        private async Task<Order> RetrieveAssociatedOrderAsync(byte portfolioId, EfrpTradeDto efrpTradeDto)
        {

            Logger.LogInformation("Retrieving associated efrp orders...");
            //The following logic is needed because in case of EFRP we dont get any information about the related order or rebalancing in the trade affirm
            IEnumerable<Order> orders = await OrderRepository.GetByInstrumentAndTradeDateAsync(efrpTradeDto.FutureContractId, efrpTradeDto.TradeDate);

            IEnumerable<Order> efrpOrders = orders.Where(x => x.IsEfrp
            && x.InstrumentId == efrpTradeDto.FutureContractId
            && x.TradeDate == efrpTradeDto.TradeDate)
                .ToList();
            if (efrpOrders.Count() == 1)
            {

                Order efrpOrder = efrpOrders.Single();
                if (efrpOrder.OrderAllocations.Count() == 1)
                {
                    Logger.LogInformation($"On EFRP Order found {efrpOrder}...");
                    // At the moment we don't use block orders for EFRP and only way to detect the correct associated order is via portoflio allocation. 
                    OrderAllocation orderAllocation = efrpOrder.OrderAllocations.Single();
                    if (orderAllocation.PortfolioId == portfolioId)
                    {
                        return efrpOrder;

                    }
                    else
                    {
                        var message = $"Efrp Trade {efrpTradeDto.ClientSide} {efrpTradeDto.Quantity} {efrpTradeDto.BloombergSymbol} {efrpTradeDto.TradeDate.ToString("yyyy-MM-dd")} couldn't be captured because no order allocation associated with portfolio {portfolioId} was found";
                        Logger.LogError(message);
                        throw new InvalidOperationException(message);
                    }
                }
                else
                {
                    var message = $"Efrp Trade {efrpTradeDto.ClientSide} {efrpTradeDto.Quantity} {efrpTradeDto.BloombergSymbol} {efrpTradeDto.TradeDate.ToString("yyyy-MM-dd")} couldn't be captured because multiple order allocation were found. Efrp orders don't support block trading.";
                    Logger.LogError(message);
                    throw new InvalidOperationException();
                }
            }
            else if (efrpOrders.Count() > 1)// case we run many rebalancing the same day
            {
                var message = $"Efrp Trade {efrpTradeDto.ClientSide} {efrpTradeDto.Quantity} {efrpTradeDto.BloombergSymbol} {efrpTradeDto.TradeDate.ToString("yyyy-MM-dd")} couldn't be captured because mutliple orders associable with this trade were found.";
                Logger.LogError(message);
                throw new InvalidOperationException(message);
            }
            else
            {
                var message = $"Efrp Trade {efrpTradeDto.ClientSide} {efrpTradeDto.Quantity} {efrpTradeDto.BloombergSymbol} {efrpTradeDto.TradeDate.ToString("yyyy-MM-dd")} couldn't be captured because no order associated with this trade was found.";
                Logger.LogError(message);
                throw new InvalidOperationException();

            }
        }
        public async Task<RawTrade> CaptureTradeAsync(byte portfolioId, EfrpTradeDto efrpTradeDto)
        {
            Logger.LogInformation($"Capturing EFRP Trade {efrpTradeDto.ClientSide} {efrpTradeDto.Quantity} {efrpTradeDto.BloombergSymbol} {efrpTradeDto.TradeDate.ToString("yyyyMMdd")} for portfolioId:{portfolioId}");
            Order efrpOrder = await RetrieveAssociatedOrderAsync(portfolioId, efrpTradeDto);// As we dont get back any information or tradeid for efrp trades we need to reconciliate with the associated order to retrieve sufficient information for booking. No robust solution but no choice at the moment

            RawTrade capturedTrade = efrpTradeDto.Map(efrpOrder);
            capturedTrade = await RawTradeRepository.UpsertByOrderRefIdAsync(capturedTrade);
            Logger.LogInformation($"EFRP Trade {capturedTrade} Captured..");
            return capturedTrade;
        }

    }
}
