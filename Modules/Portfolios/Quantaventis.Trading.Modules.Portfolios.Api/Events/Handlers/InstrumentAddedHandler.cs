using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.Out;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
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
