using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Weights.Infrastructure.Options;
using Quantaventis.Trading.Shared.Infrastructure;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Weights.Api")]
namespace Quantaventis.Trading.Modules.Weights.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<WeightsDbContext>()
                .AddOptions()
                 .AddDaos()
                .AddRepositories()
                .AddFileReaders();

        }
        private static IServiceCollection AddOptions(this IServiceCollection services)
        {


            var azureBlobFileOptions = services.GetOptions<AzureBlobFileOptions>("weights:AzureBlobFileOptions");
            services.AddSingleton<AzureBlobFileOptions>(azureBlobFileOptions);
            return services;

        }
        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<ITargetAllocationDao, TargetAllocationDao>()
            .AddScoped<ITargetWeightDao, TargetWeightDao>()
            .AddScoped<IInstrumentDao, InstrumentDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services;
        private static IServiceCollection AddFileReaders(this IServiceCollection services)
        {

            services.AddScoped<IWeightFileReader, WeightFileReader>(x => new WeightFileReader(';'));
            services.AddScoped<IAzureBlobFileReader, AzureBlobFileReader>();
            return services;
           // return services.AddScoped<IAzureBlobFileDownloadService, AzureBlobFileDownloadService>()
           // .AddScoped<IAzureBlobFileIntegrationService, AzureBlobFileIntegrationService>()

           // .AddScoped<IDBIntegrationService<StgTargetWeight>, StgRefDataUpdateService>()
           // .AddScoped<IFileParsingService<StgTargetWeight>, StgTargetWeightParsingService>()
           //// .AddScoped<ITargetWeightIntegrationService, TargetWeightIntegrationService>()
           // .AddScoped<IFileToDBIntegrationService, FileToDBIntegrationService>(); ;
        }

    }
}
