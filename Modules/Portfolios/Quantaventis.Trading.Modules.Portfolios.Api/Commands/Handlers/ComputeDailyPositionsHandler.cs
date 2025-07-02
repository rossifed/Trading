using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Portfolios.Api.Events.Out;
using Quantaventis.Trading.Modules.Portfolios.Api.Mappers;
using Quantaventis.Trading.Modules.Portfolios.Api.Dto;
using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.Portfolios.Api.Services;
namespace Quantaventis.Trading.Modules.Portfolios.Api.Commands.Handlers
{
    internal class ComputeDailyPoisitionsHandler : ICommandHandler<ComputeDailyPositions>
    {

        private IMessageBroker MessageBroker { get; }


        private IPositionUpdateService PositionUpdateService { get; }

        private ILogger<CreatePortfolioHandler> Logger { get; }

        public ComputeDailyPoisitionsHandler(
            IPositionUpdateService positionUpdateService,

            IMessageBroker messageBroker,
            ILogger<CreatePortfolioHandler> logger)
        {
            this.PositionUpdateService = positionUpdateService;

            this.MessageBroker = messageBroker;
            this.Logger = logger;

        }


        public async Task HandleAsync(ComputeDailyPositions command, CancellationToken cancellationToken = default)
        {

           await PositionUpdateService.ComputeDailyPositions();

        }

    }

}
