using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quantaventis.Trading.Modules.Instruments.Api.Dto;
using Quantaventis.Trading.Modules.Instruments.Api.Queries.In;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Shared.Infrastructure.Modules;

namespace Quantaventis.Trading.Modules.Instruments.Api;

internal class InstrumentsModule : IModule
{
    public string Name { get; } = "Instruments";

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
            .Subscribe<GetInstrumentsBySymbols, IEnumerable<InstrumentDto>>("Instrument/GetBySymbols",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
             .Subscribe<GetAllInstruments, IEnumerable<InstrumentDto>>("Instrument/GetAll",
                (query, serviceProvider, cancellationToken) =>
                    serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));
    }
}
