using System.Collections.Generic;
using Quantaventis.Trading.Modules.Rolling.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Microsoft.Extensions.Hosting;

namespace Quantaventis.Trading.Modules.Rolling.Api;

internal class RollingModule : IModule
{
    public string Name { get; } = "Rolling";

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
