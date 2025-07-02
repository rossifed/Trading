using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using Quantaventis.Trading.Modules.EmsGateway.Api.Queries.In;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Shared.Infrastructure.Modules;

namespace Quantaventis.Trading.Modules.EmsGateway.Api
{

    internal class EmsGatewayModule : IModule
    {
        public string Name { get; } = "EmsGateway";

        public void Configure(IHostBuilder hostBuilder)
        {
            throw new NotImplementedException();
        }

        public void Register(IServiceCollection services)
        {
            services.AddModule();
        }

        public void Use(IApplicationBuilder app)
        {
   


            app.UseModuleRequests()
            .Subscribe<GetEmsxOrdersByRefId, IEnumerable<EmsxOrderDto>>("EmsxOrder/GetByRefIds",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
             .Subscribe<GetAllEmsxOrders, IEnumerable<EmsxOrderDto>>("EmsxOrder/GetAll",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
             .Subscribe<GetCancelledEmsxOrders, IEnumerable<EmsxOrderDto>>("EmsxOrder/GetCancelled",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
               .Subscribe<GetFilledEmsxOrders, IEnumerable<EmsxOrderDto>>("EmsxOrder/GetFilled",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
                 .Subscribe<GetBasketOrders, IEnumerable<EmsxOrderDto>>("EmsxOrder/GetByBasket",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
                      .Subscribe<GetEmsxOrdersByStatus, IEnumerable<EmsxOrderDto>>("EmsxOrder/GetByStatus",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
                     .Subscribe<GetWorkingEmsxOrders, IEnumerable<EmsxOrderDto>>("EmsxOrder/GetWorking",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
                   .Subscribe<GetAllBaskets, IEnumerable<string>>("EMSXBasket/GetAll",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));
        }
    }
}
