using System.Collections.Generic;
using Quantaventis.Trading.Modules.Valuation.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using Quantaventis.Trading.Shared.Abstractions.Modules;

namespace Quantaventis.Trading.Modules.Valuation.Api;

internal class ValuationModule : IModule
{
    public string Name { get; } = "Valuation";

 

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
