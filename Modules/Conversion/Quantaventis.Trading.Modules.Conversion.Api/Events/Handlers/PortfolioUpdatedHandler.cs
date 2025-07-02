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
    internal class PortfolioUpdatedHandler : IEventHandler<PortfolioUpdated>
    {

        private IPortfolioDao PortfolioDao { get; }
        private IMessageBroker MessageBroker { get; }

        private ILogger<PortfolioUpdatedHandler> Logger { get; }
        public PortfolioUpdatedHandler(
            IPortfolioDao portfolioDao,
            IMessageBroker messageBroker,
            ILogger<PortfolioUpdatedHandler> logger) { 
            this.PortfolioDao = portfolioDao;
            this.MessageBroker = messageBroker;
            this.Logger = logger;
        
        }
        public async Task HandleAsync(PortfolioUpdated @event, CancellationToken cancellationToken = default)
        {
            var entity = @event.Portfolio.Map();
            await PortfolioDao.UpdateAsync(entity);
     
        }
    }
}
