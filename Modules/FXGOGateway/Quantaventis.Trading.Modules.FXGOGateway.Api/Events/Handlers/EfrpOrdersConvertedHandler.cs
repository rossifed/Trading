using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Events.In;
using Quantaventis.Trading.Modules.FXGOGateway.Api.ACL;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Dto;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Services;
using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.Events.Handlers
{
    internal class EfrpOrdersConvertedHandler : IEventHandler<EfrpOrdersConverted>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<EfrpOrdersConvertedHandler> Logger { get; }
        private IFXGOFileGenerationService<EfrpOrderDto> FXGOFileGenerationService { get;}

        public EfrpOrdersConvertedHandler(
        IFXGOFileGenerationService<EfrpOrderDto> fXGOFileGenerationService,
            IMessageBroker messageBroker,

            ILogger<EfrpOrdersConvertedHandler> logger)              
        {
            this.FXGOFileGenerationService = fXGOFileGenerationService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }

     
        public async Task HandleAsync(EfrpOrdersConverted @event, CancellationToken cancellationToken = default)
        {      
            await FXGOFileGenerationService.GenerateFXGOFileAsync(@event.EfrpOrders);
      
        }

    }

}
