using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Transmission.Api.Events.In;
using Quantaventis.Trading.Modules.Transmission.Api.Services;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.Transmission.Api.Events.Handlers
{
    internal class TradesBookedEventHandler : IEventHandler<TradesBooked>
    {
        private IFileTransmissionService FileTransmissionService { get; }
        private ILogger<TradesBookedEventHandler> Logger { get; }
 
        public TradesBookedEventHandler(
            IFileTransmissionService fileTransmissionService,
            ILogger<TradesBookedEventHandler> logger)              
        {
            this.Logger = logger;
            this.FileTransmissionService = fileTransmissionService;
        }

     
        public async Task HandleAsync(TradesBooked @event, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Event {@event} received with {@event.Trades.Count()} trades booked");      
            if (@event.Trades.Any())
            await FileTransmissionService.GenerateAndTransmitAllAsync();


        }

    }

}
