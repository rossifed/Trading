using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quantaventis.Trading.Shared.Abstractions.Modules;

namespace Quantaventis.Trading.Modules.MarketData.Api;

internal class MarketDataModlue : IModule
{
    public string Name { get; } = "MarketData";

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
        //app.UseModuleRequests()
        //    .Subscribe<GetInstrumentsBySymbols, IEnumerable<InstrumentDto>>("Instrument/GetBySymbols",
        //        (query, serviceProvider, cancellationToken) =>
        //            serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken))
        //     .Subscribe<GetAllInstruments, IEnumerable<InstrumentDto>>("Instrument/GetAll",
        //        (query, serviceProvider, cancellationToken) =>
        //            serviceProvider.GetRequiredService<IQueryDispatcher>().QueryAsync(query, cancellationToken));
    }
}
