using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Instruments.Api.Dto;
using Quantaventis.Trading.Modules.Instruments.Api.Mappers;
using Quantaventis.Trading.Modules.Instruments.Api.Queries.In;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Abstractions.Queries;

namespace Quantaventis.Trading.Modules.Instruments.Api.Queries.Handlers
{
    internal sealed class GetAllInstrumentsHandler : IQueryHandler<GetAllInstruments, IEnumerable<InstrumentDto>>
    {
        private IInstrumentDao InstrumentDao { get; }
        private IMessageBroker MessageBroker { get; }
        private ILogger<GetAllInstrumentsHandler> Logger { get; }
        public GetAllInstrumentsHandler(IInstrumentDao instrumentDao,
            IMessageBroker messageBroker,
            ILogger<GetAllInstrumentsHandler> logger)
        {

            this.InstrumentDao = instrumentDao;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        }
        public async Task<IEnumerable<InstrumentDto>> HandleAsync(GetAllInstruments query, CancellationToken cancellationToken = default)
        {
            var entities = await InstrumentDao.GetAllAsync();
            return entities.Map();
        }
    }
}
