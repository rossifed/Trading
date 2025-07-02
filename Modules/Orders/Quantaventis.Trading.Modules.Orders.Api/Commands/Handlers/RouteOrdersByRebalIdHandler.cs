using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Orders.Api.Commands;
using Quantaventis.Trading.Shared.Abstractions.Commands;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Quantaventis.Trading.Modules.Orders.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Orders.Domain.Repositories;
using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Entities = Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Orders.Api.Events.In;
using Quantaventis.Trading.Modules.Orders.Api.Events.Out;
using Quantaventis.Trading.Modules.Orders.Api.Mappers;
using Quantaventis.Trading.Modules.Orders.Api.Services;

namespace Quantaventis.Trading.Modules.Orders.Api.Commands.Handlers
{
    internal class RouteOrdersByRebalIdHandler : ICommandHandler<RouteOrdersByRebalId>
    {
        private IOrderRoutingService OrderRoutingService { get; }

        private ILogger<RouteOrdersByRebalIdHandler> Logger { get; }
 
        public RouteOrdersByRebalIdHandler(
            IOrderRoutingService orderRoutingService,
            ILogger<RouteOrdersByRebalIdHandler> logger)
        {
            this.OrderRoutingService = orderRoutingService;
            this.Logger = logger;
        }

     
        public async Task HandleAsync(RouteOrdersByRebalId command, CancellationToken cancellationToken = default)
        {
            Logger.LogInformation($"Command {command} received..");
            await OrderRoutingService.RouteByRebalancingId(command.RebalancingSessionId);
        }     

    }

}
