using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System;
using Quantaventis.Trading.Modules.FileWatcher.Infrastructure;
namespace Quantaventis.Trading.Modules.FileWatcher.Api

{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
          
            services.AddControllers();
            return services.AddInfrastructure();

        }
        private static IServiceCollection AddClients(this IServiceCollection services)
        {
            return services;
        }
      
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services;

       
    
    }
}
