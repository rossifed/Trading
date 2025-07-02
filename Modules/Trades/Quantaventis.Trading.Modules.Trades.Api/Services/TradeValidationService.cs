using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Trades.Infrastructure.Repositories;
namespace Quantaventis.Trading.Modules.Trades.Api.Services
{
    internal interface ITradeValidationService {

        Task ValidateTradesAsync();
    
    }
    internal class TradeValidationService : ITradeValidationService
    {
        private ITradeValidationRepository TradeValidationRepository { get; }
        private ILogger<TradeValidationService> Logger { get; }

        private IMessageBroker MessageBroker { get; }
        public TradeValidationService(
            ITradeValidationRepository tradeValidationRepository,
            ILogger<TradeValidationService> logger,
             IMessageBroker messageBroker
           )
        {
            TradeValidationRepository = tradeValidationRepository;
            Logger = logger;
            MessageBroker = messageBroker;
        }

        public async Task ValidateTradesAsync()
        {
            await TradeValidationRepository.ValidateTradesAsync();
        }
    }
}
