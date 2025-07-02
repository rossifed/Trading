using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dao;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Repositories;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Services;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.EFRP.Api")]
namespace Quantaventis.Trading.Modules.EFRP.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<EfrpDbContext>()
                .AddDaos()
                .AddRepositories()
                .AddServices();


        }

        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<IEfrpConversionRuleDao, EfrpConversionRuleDao>()
            .AddScoped<IFutureContractDao, FutureContractDao>()
            .AddScoped<IIMMDateDao, IMMDateDao>()
            .AddScoped<IEfrpOrderDao, EfrpOrderDao>()
            .AddScoped<IGenericFutureDao, GenericFutureDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IEfrpConversionRuleRepository, EfrpConversionRuleRepository>()
            .AddScoped<IFutureContractRepository, FutureContractRepository>()
            .AddScoped<IIMMDateRepository, IMMDateRepository>()
            .AddScoped<IEfrpOrderRepository, EfrpOrderRepository>();
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services.AddScoped<IMsTradeAffirmFileReader, MsTradeAffirmFileReader>();


    }
}
