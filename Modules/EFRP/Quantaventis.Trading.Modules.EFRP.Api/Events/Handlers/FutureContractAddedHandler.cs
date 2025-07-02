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
    internal class FutureContractAddedHandler : IEventHandler<FutureContractAdded>
    {

        private IMessageBroker MessageBroker { get; }

        private ILogger<FutureContractAddedHandler> Logger { get; }
        private IFutureContractDao FutureContractDao { get;}

        private IGenericFutureDao GenericFutureDao { get; }
        public FutureContractAddedHandler(
        IGenericFutureDao genericFutureDao,
            IMessageBroker messageBroker,

            ILogger<FutureContractAddedHandler> logger)              
        {
            this.GenericFutureDao = genericFutureDao;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
            this.MessageBroker = messageBroker;
        }

     
        public async Task HandleAsync(FutureContractAdded @event, CancellationToken cancellationToken = default)
        {
            var futureContractDto = @event.FutureContract;
            var genericFutureDto = @event.GenericFuture;
            var futureContract = futureContractDto.Map(genericFutureDto.Id);
            var genericFuture = genericFutureDto.Map();
            await GenericFutureDao.SaveAsync(genericFuture);
            await FutureContractDao.SaveAsync(futureContract);
        }

    }

}
