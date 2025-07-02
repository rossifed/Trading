using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quantaventis.Trading.Modules.EMSX.Api.Queries.In;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Shared.Infrastructure.Modules;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.DTO;
namespace Quantaventis.Trading.Modules.EMSX.Api
{

    internal class EMSXModule : IModule
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
            .Subscribe<GetSessionStatus, string>("Status",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
            .Subscribe<GetEmsxFillsByOrderId, IEnumerable<EmsxFillDto>>("EMSX/GetFillsByOrderId",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));
            ;
        }
    }
}
