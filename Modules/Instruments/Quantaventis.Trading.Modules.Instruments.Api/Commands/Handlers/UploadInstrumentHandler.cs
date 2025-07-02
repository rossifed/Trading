using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Instruments.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Instruments.Api.Commands.Handlers
{
    internal class UploadInstrumentsHandler : ICommandHandler<UploadInstruments>
    {

        private IMessageBroker MessageBroker { get; }
        private IInstrumentUpdateService InstrumentUpdateService { get; }



        private ILogger<UploadInstrumentsHandler> Logger { get; }


        public UploadInstrumentsHandler(
           IInstrumentUpdateService instrumentUpdateService,
            IMessageBroker messageBroker,
            ILogger<UploadInstrumentsHandler> logger)
        {
            this.InstrumentUpdateService = instrumentUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(UploadInstruments command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Integrating Ref Data from {command.AzureBlobFile}");


            await InstrumentUpdateService.UpdateAsync(command.AzureBlobFile);





        }

    }

}
