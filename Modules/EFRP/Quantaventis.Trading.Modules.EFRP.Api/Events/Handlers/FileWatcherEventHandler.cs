using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EFRP.Api.Events.In;
using Quantaventis.Trading.Modules.EFRP.Api.Mappers;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EFRP.Api.Events.In;
using Quantaventis.Trading.Module.EFRP.Infrastructure.Events.In;
namespace Quantaventis.Trading.Modules.EFRP.Api.Events.Handlers
{
    internal class FileWatcherEventHandler : IEventHandler<FileWatcherEvent>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<OrdersGeneratedHandler> Logger { get; }
        private IMsTradeAffirmService MsTradeAffirmService { get;}
        public FileWatcherEventHandler(
        IMsTradeAffirmService msTradeAffirmService,
            IMessageBroker messageBroker,

            ILogger<OrdersGeneratedHandler> logger)              
        {
            this.MsTradeAffirmService = msTradeAffirmService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }

     
        public async Task HandleAsync(FileWatcherEvent @event, CancellationToken cancellationToken = default)
        {
            if (@event.Topic == "MSTradeAffirm") {
               await  MsTradeAffirmService.OnMsTradeAffirmFile(Convert.ToByte(@event.Metadata["PortfolioId"]), @event.FilePath);
            }
        }

    }

}
