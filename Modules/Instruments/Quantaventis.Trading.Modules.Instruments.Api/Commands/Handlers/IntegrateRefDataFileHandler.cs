using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Instruments.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Instruments.Api.Commands.Handlers
{
    internal class IntegrateRefDataFileHandler : ICommandHandler<IntegrateRefDataFile>
    {

        private IMessageBroker MessageBroker { get; }
        private IInstrumentUpdateService InstrumentUpdateService { get; }



        private ILogger<IntegrateRefDataFileHandler> Logger { get; }


        public IntegrateRefDataFileHandler(
            IInstrumentUpdateService instrumentUpdateService,
            IMessageBroker messageBroker,
            ILogger<IntegrateRefDataFileHandler> logger)
        {
            this.InstrumentUpdateService = instrumentUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(IntegrateRefDataFile command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Integrating Ref Data from {command.AzureBlobFilePath}");


            await InstrumentUpdateService.UpdateAsync(command.AzureBlobFilePath);





        }

    }

}
