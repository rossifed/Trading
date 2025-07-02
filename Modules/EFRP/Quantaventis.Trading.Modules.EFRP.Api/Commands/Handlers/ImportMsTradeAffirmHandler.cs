using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EFRP.Api.Commands;
using Quantaventis.Trading.Modules.EFRP.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Services;
using CsvHelper;
using Quantaventis.Trading.Modules.EFRP.Api.Commands;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dto;
namespace Quantaventis.Trading.Modules.EFRP.Api.Commands.Handlers
{
    internal class ImportMsTradeAffirmHandler : ICommandHandler<ImportMsTradeAffirm>
    {

        private IMessageBroker MessageBroker { get; }


        private IMsTradeAffirmService MsTradeAffirmService { get; }

        private ILogger<ImportMsTradeAffirmHandler> Logger { get; }


        public ImportMsTradeAffirmHandler(
            IMsTradeAffirmService msTradeAffirmService,
            IMessageBroker messageBroker,
            ILogger<ImportMsTradeAffirmHandler> logger)
        { 
        
            this.MsTradeAffirmService = msTradeAffirmService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(ImportMsTradeAffirm command, CancellationToken cancellationToken = default)
        {
          await MsTradeAffirmService.OnMsTradeAffirmFile(command.PortfolioId, command.FilePath);
    
        }

    }

}
