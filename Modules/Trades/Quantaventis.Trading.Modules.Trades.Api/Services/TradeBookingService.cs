using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Trades.Api.Events.Out;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Trades.Api.Mappers;
namespace Quantaventis.Trading.Modules.Trades.Api.Services
{
    internal interface ITradeBookingService
    {
        Task StageAndBookTradesAsync();
        Task StageTradesAsync();
        Task BookTradesAsync();

    }
    internal class TradeBookingService : ITradeBookingService
    {
        private ITradeBookingRepository TradeBookingRepository { get; }

        private ITradeValidationRepository TradeValidationRepository { get; }

        private ITradeStagingRepository TradeStagingRepository { get; }
        private ILogger<TradeBookingService> Logger { get; }

        private IMessageBroker MessageBroker { get; }

        public TradeBookingService(ITradeBookingRepository tradeBookingRepository,
            ITradeStagingRepository tradeStagingRepository,
            ITradeValidationRepository tradeValidationRepository,
            ILogger<TradeBookingService> logger,
            IMessageBroker messageBroker)
        {
            TradeBookingRepository = tradeBookingRepository;
            Logger = logger;
            MessageBroker = messageBroker;
            TradeStagingRepository = tradeStagingRepository;
            TradeValidationRepository = tradeValidationRepository;
        }
        public async Task StageTradesAsync()
        {
            await TradeStagingRepository.StageTradesAsync();
        }

        public async Task StageAndBookTradesAsync()
        {
            await StageTradesAsync();
            await BookTradesAsync();
        }

        public async Task BookTradesAsync()
        {
            await TradeValidationRepository.ValidateTradesAsync();
            IEnumerable<Trade> bookedTrades = await TradeBookingRepository.BookTradesAsync();
            await MessageBroker.PublishAsync(new TradesBooked(bookedTrades.Map()));
        }
    }
}
