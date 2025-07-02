using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Weights.Api.Events.Out;
using Quantaventis.Trading.Modules.Weights.Api.Dto;
using Quantaventis.Trading.Modules.Weights.Api.Events.Out;
using Quantaventis.Trading.Modules.Weights.Api.Mappers;
using Quantaventis.Trading.Modules.Weights.Api.Services;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Entities = Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Weights.Api.Commands.Handlers
{
    internal class InstrumentAddedHandler : IEventHandler<InstrumentAdded>
    {

        private ILogger<InstrumentAddedHandler> Logger { get; }

       private IInstrumentDao InstrumentDao { get; }
        public InstrumentAddedHandler(
            IInstrumentDao instrumentDao,
            ILogger<InstrumentAddedHandler> logger)
        {

            this.Logger = logger;
            this.InstrumentDao = instrumentDao;
        }


        public async Task HandleAsync(InstrumentAdded command, CancellationToken cancellationToken = default)
        {
            var instrumentDto = command.Instrument;
            var supportedInstrumentTypes = new string[] { "GENFUT", "EQU", "CurrencyPair" };
            if (supportedInstrumentTypes.Contains(instrumentDto.InstrumentType))
            {
                await InstrumentDao.CreateAsync(instrumentDto.Map());
            }
 
        }

   
    }

}
