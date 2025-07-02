using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Services;
using System.Runtime.CompilerServices;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
using Quantaventis.Trading.Modules.Transmission.Domain.Repositories;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Repositories;
using Quantaventis.Trading.Shared.Infrastructure;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Options;
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.Transmission.Api")]
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure
{
    internal static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddDatabase<TransmissionDbContext>()
                .AddOptions()
                .AddDaos()
                .AddRepositories()
                .AddServices();


        }

        private static IServiceCollection AddOptions(this IServiceCollection services)
        {


            GpgEncryptionOptions mappingOptions = services.GetOptions<GpgEncryptionOptions>("transmission:GpgEncryption");
            services.AddSingleton(mappingOptions);

            SmtpOptions smtpOptions = services.GetOptions<SmtpOptions>("transmission:SMTP");
            services.AddSingleton(smtpOptions);

            FileArchivingOptions archivingOptions = services.GetOptions<FileArchivingOptions>("transmission:FileArchiving");
            services.AddSingleton(archivingOptions);

            return services;

        }
        private static IServiceCollection AddDaos(this IServiceCollection services)
            => services.AddScoped<ITransmissionProfileDao, TransmissionProfileDao>()
            .AddScoped<IFileTransmissionDao, FileTransmissionDao>()
            .AddScoped<IBookedTradeAllocationDao, BookedTradeAllocationDao>();


        private static IServiceCollection AddRepositories(this IServiceCollection services)
            => services.AddScoped<IFileTransmissionRepository, FileTransmissionRepository>()
            .AddScoped<ITransmissionProfileRepository, TransmissionProfileRepository>();
        private static IServiceCollection AddServices(this IServiceCollection services)
             => services.AddScoped<IDataFetcher, DataFetcher>()
            .AddScoped<IEmailSender, EmailSender>()
            .AddScoped<IFileArchiver, FileArchiver>()
            .AddScoped<IFileContentGenerator, FileContentGenerator>()
            .AddScoped<IFileWriter, FileWriter>()
            .AddScoped<IFtpUploader, FtpUploader>()
            .AddScoped<IFileEncryptor, GpgEncryptor>();
    }
}
