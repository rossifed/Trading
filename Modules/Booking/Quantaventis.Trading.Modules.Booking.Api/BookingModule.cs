using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using Quantaventis.Trading.Shared.Infrastructure.Modules;

namespace Quantaventis.Trading.Modules.Booking.Api
{

    internal class BookingModule : IModule
    {
        public string Name { get; } = "Booking";

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
}
