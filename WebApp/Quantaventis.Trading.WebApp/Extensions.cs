using Quantaventis.Trading.Shared.Infrastructure.Modules;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Shared.Infrastructure;
using System.Linq;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;


namespace Quantaventis.Trading.WebApp
{
    public static class Extensions
    {
        public static IEnumerable<IModule> RegisterModules(this  IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = ModuleLoader.LoadAssemblies(configuration);
            var modules = ModuleLoader.LoadModules(assemblies);
            var guiConnectors = ModuleLoader.LoadModuleGuiConnector(assemblies);
            services.AddModularInfrastructure( configuration, assemblies, modules, guiConnectors);
            modules.ToList().ForEach(module => module.Register(services));
            guiConnectors.ToList().ForEach(guiConnector => guiConnector.Register(services));
            return modules;
        }
       
        public  static void UseModules(this IEnumerable<IModule> modules, IApplicationBuilder app)
        => modules.ToList().ForEach(module => module.Use(app));


        public static void ConfigureModules(this IEnumerable<IModule> modules, IHostBuilder hostBuilder)
         => modules.ToList().ForEach(module => module.Configure(hostBuilder));

       

        
    }
}
