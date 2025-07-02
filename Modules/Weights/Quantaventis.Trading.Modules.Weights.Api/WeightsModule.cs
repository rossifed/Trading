using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quantaventis.Trading.Shared.Abstractions.Modules;

namespace Quantaventis.Trading.Modules.Weights.Api;

internal class WeightsModule : IModule
{
    public string Name { get; } = "Weights";

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
    }
}
