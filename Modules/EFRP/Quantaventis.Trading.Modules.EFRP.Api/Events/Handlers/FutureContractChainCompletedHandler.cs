using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EFRP.Api.Events;
using Quantaventis.Trading.Modules.EFRP.Api.Events.In;
using Quantaventis.Trading.Modules.EFRP.Api.Mappers;
using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Domain.Services;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dao;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;

namespace Quantaventis.Trading.Modules.EFRP.Api.Events.Handlers
{
    internal class FutureContractChainCompletedHandler : IEventHandler<FutureContractChainCompleted>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<FutureContractChainCompletedHandler> Logger { get; }
        private IFutureContractDao FutureContractDao { get;}

        private IGenericFutureDao GenericFutureDao { get; }
        public FutureContractChainCompletedHandler(
        IGenericFutureDao genericFutureDao,
            IMessageBroker messageBroker,

            ILogger<FutureContractChainCompletedHandler> logger)              
        {
            this.GenericFutureDao = genericFutureDao;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }

     
        public async Task HandleAsync(FutureContractChainCompleted @event, CancellationToken cancellationToken = default)
        {
            var futureContractDtos = @event.FutureContracts;
            var genericFutureDto = @event.GenericFuture;
            var futureContracts = futureContractDtos.Map(genericFutureDto.Id);
            await FutureContractDao.SaveRangeAsync(futureContracts);
        }

    }

}
