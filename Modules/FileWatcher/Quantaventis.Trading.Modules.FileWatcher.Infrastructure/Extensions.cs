using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Module.FileWatcher.Infrastructure.Configuration;
using Quantaventis.Trading.Module.FileWatcher.Infrastructure.Services;
using Quantaventis.Trading.Shared.Infrastructure;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Quantaventis.Trading.Modules.FileWatcher.Api")]
namespace Quantaventis.Trading.Modules.FileWatcher.Infrastructure
{
    internal static class Extensions
    {
        internal static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddOptions().AddServices();


        }
        private static IServiceCollection AddOptions(this IServiceCollection services)
        {
            FileWatcherOptions fileWatcherOptions = services.GetOptions<FileWatcherOptions>("filewatcher:FileWatcherOptions");
            services.AddSingleton(fileWatcherOptions);
            return services;
        }


        private static IServiceCollection AddServices(this IServiceCollection services)
        {
     
            services.AddHostedService<FileWatcherService>();
            return services;
        }
    }
}
