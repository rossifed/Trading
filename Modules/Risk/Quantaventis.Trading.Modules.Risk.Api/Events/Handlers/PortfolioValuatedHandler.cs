using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Risk.Api.Events.In;
using Quantaventis.Trading.Modules.Risk.Api.Mappers;

using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Risk.Api.Events.Handlers
{
    internal class PortfolioValuatedHandler : IEventHandler<PortfolioValuated>
    {

    

        private ILogger<PortfolioValuatedHandler> Logger { get; }


        private IMessageBroker MessageBroker { get; }
        public PortfolioValuatedHandler(
       
            IMessageBroker messageBroker,
            ILogger<PortfolioValuatedHandler> logger)
        {

            Logger = logger;
            this.MessageBroker = messageBroker;
           
      
        }


        public async Task HandleAsync(PortfolioValuated @event, CancellationToken cancellationToken = default)
        {
            var dto = @event.PortfolioValuation;



        }
    }
}
