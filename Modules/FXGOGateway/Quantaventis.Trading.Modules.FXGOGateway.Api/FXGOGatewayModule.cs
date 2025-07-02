
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Shared.Infrastructure.Modules;


namespace Quantaventis.Trading.Modules.FXGOGateway.Api;

internal class FXGOGatewayModule : IModule
{
    public string Name { get; } = "FXGOGateway";



    public void Configure(IHostBuilder hostBuilder)
    {

    }



    public void Register(IServiceCollection services)
    {
        services.AddModule();
    }
        
    public void Use(IApplicationBuilder app)
    {
    }
}
