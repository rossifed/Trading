using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quantaventis.Trading.Modules.EFRP.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Shared.Infrastructure.Modules;
using Quantaventis.Trading.Modules.EFRP.Api.Queries.In;

namespace Quantaventis.Trading.Modules.EFRP.Api;

internal class EFRPModule : IModule
{
    public string Name { get; } = "EFRP";

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
            .Subscribe<GetEfrpConversionInfo, IEnumerable<EfrpConversionInfoDto>>("EFRP/GetEfrpConversionInfo",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken)) ;
    }
}
