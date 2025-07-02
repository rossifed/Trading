using Quantaventis.Trading.Shared.Abstractions.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Conversion.Api.Events.In;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Conversion.Api.Mappers;
using Quantaventis.Trading.Modules.Conversion.Api.Events.Out;

namespace Quantaventis.Trading.Modules.Conversion.Api.Events.Handlers
{
    internal class PortfolioCreatedHandler : IEventHandler<PortfolioCreated>
    {

        private IPortfolioDao PortfolioDao { get; }
        private IMessageBroker MessageBroker { get; }

        private ILogger<PortfolioCreatedHandler> Logger { get; }
        public PortfolioCreatedHandler(
            IPortfolioDao portfolioDao,
            IMessageBroker messageBroker,
            ILogger<PortfolioCreatedHandler> logger) { 
            this.PortfolioDao = portfolioDao;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        
        }
        public async Task HandleAsync(PortfolioCreated @event, CancellationToken cancellationToken = default)
        {
            var entity = @event.Portfolio.Map();
            await PortfolioDao.CreateAsync(entity);
     
        }
    }
}
