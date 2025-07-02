using System.Collections.Generic;
using Quantaventis.Trading.Modules.Portfolios.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Microsoft.Extensions.Hosting;

namespace Quantaventis.Trading.Modules.Portfolios.Api;

internal class PortfoliosModule : IModule
{
    public string Name { get; } = "Portfolios";

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
