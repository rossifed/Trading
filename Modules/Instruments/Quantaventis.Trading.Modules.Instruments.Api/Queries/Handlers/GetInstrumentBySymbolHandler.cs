using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Instruments.Api.Dto;
using Quantaventis.Trading.Modules.Instruments.Api.Mappers;
using Quantaventis.Trading.Modules.Instruments.Api.Queries.In;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.Instruments.Api.Queries.Handlers
{
    internal sealed class GetInstrumentBySymbolHandler : IQueryHandler<GetInstrumentBySymbol, InstrumentDto?>
    {
        private IInstrumentDao InstrumentDao { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetInstrumentBySymbolHandler> Logger { get; }
        public GetInstrumentBySymbolHandler(IInstrumentDao instrumentDao,
            IMessageBroker messageBroker,
            ILogger<GetInstrumentBySymbolHandler> logger)
        {

            this.InstrumentDao = instrumentDao;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }
        public async Task<InstrumentDto?> HandleAsync(GetInstrumentBySymbol query, CancellationToken cancellationToken = default)
        {
            var entities = await InstrumentDao.GetBySymbolAsync(query.Symbol);
            return entities?.Map();
        }
    }
}
