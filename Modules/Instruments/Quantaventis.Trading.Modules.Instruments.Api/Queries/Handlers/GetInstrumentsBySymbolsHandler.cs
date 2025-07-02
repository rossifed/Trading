using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Instruments.Api.Dto;
using Quantaventis.Trading.Modules.Instruments.Api.Mappers;
using Quantaventis.Trading.Modules.Instruments.Api.Queries.In;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.Instruments.Api.Queries.Handlers
{
    internal sealed class GetInstrumentsBySymbolsHandler : IQueryHandler<GetInstrumentsBySymbols, IEnumerable<InstrumentDto>>
    {
        private IInstrumentDao InstrumentDao { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetInstrumentsBySymbolsHandler> Logger { get; }
        public GetInstrumentsBySymbolsHandler(IInstrumentDao instrumentDao,
            IMessageBroker messageBroker,
            ILogger<GetInstrumentsBySymbolsHandler> logger)
        {

            this.InstrumentDao = instrumentDao;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }
        public async Task<IEnumerable<InstrumentDto>> HandleAsync(GetInstrumentsBySymbols query, CancellationToken cancellationToken = default)
        {
            var entities = await InstrumentDao.GetBySymbolsAsync(query.Symbols);
            return entities.Map();
        }
    }
}
