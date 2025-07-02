using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
namespace Quantaventis.Trading.Modules.Booking.Domain.Service
{
    internal interface ITradeEnricher
    {
        Task<EnrichedTrade> EnrichTradeAsync(RawTrade rawTrade);
    }
    internal class TradeEnricher : ITradeEnricher
    {
        private ITradeInstrumentTypeRepository TradeInstrumentTypeRepository { get; }
        private IInstrumentRepository InstrumentRepository { get; }
        private IFutureSwapRepository FutureSwapRepository { get; }
        private IExecutionTypeRepository ExecutionTypeRepository { get; }
        private IOrderRepository OrderRepository { get; }
        private IExecutionDeskRepository ExecutionDeskRepository { get; }
        private ILogger<TradeEnricher> Logger { get; }
        public TradeEnricher(ITradeInstrumentTypeRepository tradeInstrumentTypeRepository,
            IInstrumentRepository instrumentRepository,
            IFutureSwapRepository futureSwapRepository,
            IExecutionTypeRepository executionTypeRepository,
            IExecutionDeskRepository executionDeskRepository,
            IOrderRepository orderRepository,
            ILogger<TradeEnricher> logger)
        {
            TradeInstrumentTypeRepository = tradeInstrumentTypeRepository;
            InstrumentRepository = instrumentRepository;
            FutureSwapRepository = futureSwapRepository;
            ExecutionTypeRepository = executionTypeRepository;
            ExecutionDeskRepository = executionDeskRepository;
            OrderRepository = orderRepository;
            Logger = logger;
        }

        private async Task<Instrument> GetInstrumentAsync(RawTrade trade)
        {

            Instrument? instrument = await InstrumentRepository.GetBySymbolAsync(trade.Symbol);
            if (instrument == null)
                throw new Exception($"Instrument with symbol {trade.Symbol} was not found.");
            return instrument;
        }

        private Account GetExecutionAccount(RawTrade executedTrade)
        {
            return executedTrade.ExecutionAccount;
        }

        private async Task<ExecutionType> GetExecutionTypeAsync(RawTrade rawTrade, ExecutionDesk executionDesk)
        {
            string? strategy = rawTrade.StrategyType;
            ExecutionType? executionType = null;
            if (strategy != null)
            {
                executionType = await ExecutionTypeRepository.GetExecutionTypeAsync(executionDesk.Id, rawTrade.StrategyType);
            }
            if (executionType == null)
            {
                Logger.LogWarning($"Execution Type whas not fund for execution desk {executionDesk} and strategy {strategy}. Default Execution type will be used");
                executionType = await ExecutionTypeRepository.GetDefaultExecutionTypeAsync(executionDesk.Id);

                if (executionType == null)
                    throw new Exception($"No default ExecutionType  found for the  Execution Desk {executionDesk} and strategy {strategy}.");
            }

            return executionType;
        }

        private async Task<bool> IsTradedAsSwapAsync(RawTrade trade, Instrument instrument, Counterparty execBroker)
        {
            var isSwap = trade.IsCfd;
            if (!isSwap && instrument.GenericFutureId != null)
                isSwap = await FutureSwapRepository.IsTradedAsFutureSwapAsync(instrument, execBroker);

            return isSwap;
        }
        private async Task<TradeInstrumentType> GetTradeInstrumentTypeAsync(RawTrade trade, Instrument instrument, Counterparty execBroker)
        {
            var isSwap = trade.IsCfd;
            if (!isSwap && instrument.GenericFutureId != null)
                isSwap = await FutureSwapRepository.IsTradedAsFutureSwapAsync(instrument, execBroker);
            TradeInstrumentType tradeInstrumentType = await TradeInstrumentTypeRepository.GetAsync(instrument.InstrumentType, isSwap);
            return tradeInstrumentType;
        }
        private async Task<ExecutionDesk> GetExecutionDeskAsync(RawTrade trade)
        {
            var execDeskCode = trade.ExecutionDesk;
            ExecutionDesk? executionDesk = await ExecutionDeskRepository.GetByCodeAsync(execDeskCode);
            if (executionDesk == null)
                throw new Exception($"not Execution Desk found for the  code {execDeskCode}.");
            return executionDesk;
        }
        private async Task<int?> GetRebalancingIdAsync(RawTrade trade)
        {

            if (trade.OrderReferenceId != null)
            {
                int orderId = trade.OrderReferenceId.Value;
                Order? order = await OrderRepository.GetByOrderIdAsync(orderId);
                if (order == null)
                {
                    throw new Exception($"No Order found for OrderId : {orderId}");
                }
                return order.RebalancingId;
            }
            return null;

        }
        public async Task<EnrichedTrade> EnrichTradeAsync(RawTrade rawTrade)
        {
            Logger.LogInformation($"Enriching trade {rawTrade}...");
            Instrument instrument = await GetInstrumentAsync(rawTrade);
      
            TradeSide tradeSide = TradeSide.Parse(rawTrade.Side);
            Currency tradeCurrency = rawTrade.Currency;
            Money avgPriceLocal = new Money(rawTrade.AvgPrice, tradeCurrency);
            Account execAccount = GetExecutionAccount(rawTrade);
            ExecutionDesk executionDesk = await GetExecutionDeskAsync(rawTrade);
            Counterparty executionBroker = executionDesk.ExecutionBroker;
            ExecutionType executionType = await GetExecutionTypeAsync(rawTrade, executionDesk);
          
            TradeInstrumentType tradeInstrumentType = await GetTradeInstrumentTypeAsync(rawTrade, instrument, executionBroker);
            int? rebalancingId = await GetRebalancingIdAsync(rawTrade);
            return new EnrichedTrade(
                rawTrade.TradeId,
                rebalancingId,
                tradeSide,
                instrument,
                rawTrade.Quantity,
                tradeInstrumentType,
                avgPriceLocal,
                rawTrade.ExecutionChannel,
                rawTrade.ExecutionDesk,
                executionBroker,
                execAccount,
                rawTrade.TradeDate,
                rawTrade.Exchange,
                rawTrade.SettlementDate,
                executionType,
                rawTrade.InstrumentIdentifiers.CleanName(instrument),
                rawTrade.OrderDetails.AdjustQuantitySign(tradeSide),
                rawTrade.FillsDetails);
        }

    }
}
