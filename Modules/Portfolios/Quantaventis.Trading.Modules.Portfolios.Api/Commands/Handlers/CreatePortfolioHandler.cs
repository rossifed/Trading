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
    internal class CreatePortfolioHandler : ICommandHandler<CreatePortfolio>
    {

        private IMessageBroker MessageBroker { get; }


        private IPortfolioDao PortfolioDao { get; }

        private ILogger<CreatePortfolioHandler> Logger { get; }

        public CreatePortfolioHandler(
            IPortfolioDao portfolioDao,

            IMessageBroker messageBroker,
            ILogger<CreatePortfolioHandler> logger)
        {
            this.PortfolioDao = portfolioDao;

            this.MessageBroker = messageBroker;
            this.Logger = logger;

        }


        public async Task HandleAsync(CreatePortfolio command, CancellationToken cancellationToken = default)
        {
            
            var entity = new Portfolio()
            {  
                Name = command.Name,
                Mnemonic = command.Mnemonic,
                Currency = command.Currency,
            };
            var savedEntity = await PortfolioDao.CreateAsync(entity);
            Logger.LogInformation($"Portfolio {savedEntity.PortfolioId} {savedEntity.Name} {savedEntity.Mnemonic} has been created..");
            var portfolioDto = savedEntity.Map();
            await MessageBroker.PublishAsync(new PortfolioCreated(portfolioDto));

        }

    }

}
