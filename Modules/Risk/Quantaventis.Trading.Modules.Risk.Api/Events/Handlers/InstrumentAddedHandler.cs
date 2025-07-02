using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Risk.Api.Events.Out;
using Quantaventis.Trading.Modules.Risk.Api.Dto;
using Quantaventis.Trading.Modules.Risk.Api.Events.Out;
using Quantaventis.Trading.Modules.Risk.Api.Mappers;
using Quantaventis.Trading.Modules.Risk.Api.Services;
using Quantaventis.Trading.Modules.Risk.Infrastructure.Dao;

using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Entities = Quantaventis.Trading.Modules.Risk.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Risk.Api.Commands.Handlers
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
          
                await InstrumentDao.CreateAsync(instrumentDto.Map());
            
 
        }

   
    }

}
