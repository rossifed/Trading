using System.Collections.Generic;
using Quantaventis.Trading.Modules.Conversion.Api;
using Quantaventis.Trading.Modules.Conversion.Domain;
using Quantaventis.Trading.Modules.Conversion.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Microsoft.Extensions.Hosting;

namespace Quantaventis.Trading.Modules.Conversion.Api;

internal class ConversionModule : IModule
{
    public string Name { get; } = "Conversion";

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
