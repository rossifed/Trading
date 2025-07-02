using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Orders.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Modules.Transmission.Api.Services;
namespace Quantaventis.Trading.Modules.Transmission.Api.Commands.Handlers
{
    internal class GenerateAndTransmitHandler : ICommandHandler<GenerateAndTransmit>
    {
        private IFileTransmissionService FileTransmissionService { get; }

        private ILogger<GenerateAndTransmitHandler> Logger { get; }
 
        public GenerateAndTransmitHandler(
            IFileTransmissionService fileTransmissionService,
            ILogger<GenerateAndTransmitHandler> logger)
        {
            this.FileTransmissionService = fileTransmissionService;
            this.Logger = logger;
        }

     
        public async Task HandleAsync(GenerateAndTransmit command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received..");
            await FileTransmissionService.GenerateAndTransmitAsync(command.transmissionProfileId);
        }     

    }

}
