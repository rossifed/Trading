using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;

using Quantaventis.Trading.Modules.Conversion.Infrastructure;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Modules.Conversion.Domain;
using Quantaventis.Trading.Modules.Conversion.Api.Services;

namespace Quantaventis.Trading.Modules.Conversion.Api
{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
            services.AddInfrastructure()
               .AddServices()
               .AddSwaggerGen();
            services.AddControllers();
            return services;

        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services.AddDomainServices().AddScoped<IInstrumentMappingUpdateService, InstrumentMappingUpdateService>();


    }
}
