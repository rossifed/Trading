using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.MarketData.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.MarketData.Api.Commands.Handlers
{
    internal class IntegrateVolumeDataFileHandler : ICommandHandler<IntegrateVolumeDataFile>
    {

        private IMessageBroker MessageBroker { get; }
        private IVolumeDataUpdateService VolumeDataUpdateService { get; }



        private ILogger<IntegrateVolumeDataFileHandler> Logger { get; }


        public IntegrateVolumeDataFileHandler(
            IVolumeDataUpdateService volumeDataUpdateService,
            IMessageBroker messageBroker,
            ILogger<IntegrateVolumeDataFileHandler> logger)
        {
            this.VolumeDataUpdateService = volumeDataUpdateService;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }


        public async Task HandleAsync(IntegrateVolumeDataFile command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Integrating Volumes from {command.AzureBlobFile}");


            await VolumeDataUpdateService.UpdateAsync(command.AzureBlobFile);





        }

    }

}
