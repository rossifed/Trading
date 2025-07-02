using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.Out;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
{
    internal class UpdatePortfolioHandler : ICommandHandler<UpdatePortfolio>
    {

        private IMessageBroker MessageBroker { get; }


        private IPortfolioDao PortfolioDao { get; }

        private ILogger<CreatePortfolioHandler> Logger { get; }

        public UpdatePortfolioHandler(
            IPortfolioDao portfolioDao,

            IMessageBroker messageBroker,
            ILogger<CreatePortfolioHandler> logger)
        {
            this.PortfolioDao = portfolioDao;

            this.MessageBroker = messageBroker;
            this.Logger = logger;

        }


        public async Task HandleAsync(UpdatePortfolio command, CancellationToken cancellationToken = default)
        {
            
            var entity = new Portfolio()
            {   PortfolioId = command.PortfolioId,
                Name = command.Name,
                Mnemonic = command.Mnemonic,
                Currency = command.Currency,
            };
            var savedEntity = await PortfolioDao.UpdateAsync(entity);
            Logger.LogInformation($"Portfolio {savedEntity.PortfolioId} {savedEntity.Name} {savedEntity.Mnemonic} has been updated..");
            var portfolioDto = savedEntity.Map();
            await MessageBroker.PublishAsync(new PortfolioUpdated(portfolioDto));

        }

    }

}
