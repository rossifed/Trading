using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Orders.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Modules.Transmission.Api.Services;
namespace Quantaventis.Trading.Modules.Transmission.Api.Commands.Handlers
{
    internal class GenerateAndTransmitAllHandler : ICommandHandler<GenerateAndTransmitAll>
    {
        private IFileTransmissionService FileTransmissionService { get; }

        private ILogger<GenerateAndTransmitAllHandler> Logger { get; }
 
        public GenerateAndTransmitAllHandler(
            IFileTransmissionService fileTransmissionService,
            ILogger<GenerateAndTransmitAllHandler> logger)
        {
            this.FileTransmissionService = fileTransmissionService;
            this.Logger = logger;
        }

     
        public async Task HandleAsync(GenerateAndTransmitAll command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received..");
            await FileTransmissionService.GenerateAndTransmitAllAsync(command.ForceEod);
        }     

    }

}
