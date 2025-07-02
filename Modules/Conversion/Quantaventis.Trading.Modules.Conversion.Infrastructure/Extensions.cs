using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Conversion.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.Conversion.Domain.Repositories;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Conversion.Api")]
namespace Quantaventis.Trading.Modules.Conversion.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<ConversionDbContext>()
                 .AddDaos()
                .AddRepositories();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services
            .AddScoped<IInstrumentMappingDao, InstrumentMappingDao>()
            .AddScoped<ICurrencyPairConversionRuleDao, CurrencyPairConversionRuleDao>()
            .AddScoped<IInstrumentDao, InstrumentDao>()
            .AddScoped<IPortfolioDao, PortfolioDao>()
              .AddScoped<IEquityConversionRuleDao, EquityConversionRuleDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services.AddScoped<IInstrumentMappingRepository, InstrumentMappingRepository>()
            .AddScoped<IContractConversionRuleRepository, ContractConversionRuleRepository>()
              .AddScoped<ICurrencyPairConversionRuleRepository, CurrencyPairConversionRuleRepository>()
            .AddScoped<IFutureConversionRuleRepository, FutureConversionRuleRepository>()
            .AddScoped<IInstrumentRepository, InstrumentRepository>()
            .AddScoped<IEquityConversionRuleRepository, EquityConversionRuleRepository>();


    }
}
