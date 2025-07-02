using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Abstractions.Dispatchers;
using Quantaventis.Trading.Shared.Abstractions.Modules;
using Quantaventis.Trading.Shared.Infrastructure.Api;
using Quantaventis.Trading.Shared.Infrastructure.Caching;
using Quantaventis.Trading.Shared.Infrastructure.Commands;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using Quantaventis.Trading.Shared.Infrastructure.Dispatchers;
using Quantaventis.Trading.Shared.Infrastructure.Events;
using Quantaventis.Trading.Shared.Infrastructure.Messaging;
using Quantaventis.Trading.Shared.Infrastructure.Modules;
using Quantaventis.Trading.Shared.Infrastructure.Queries;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;
using Quartz;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Quantaventis.Trading.Shared.Infrastructure
{
    public static class Extensions
    {
        public static T GetOptions<T>(this IServiceCollection services, string sectionName) where T : new()
        {
            using var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            return configuration.GetOptions<T>(sectionName);
        }

        public static T GetOptions<T>(this IConfiguration configuration, string sectionName) where T : new()
        {
            var options = new T();
            configuration.GetSection(sectionName).Bind(options);
            return options;
        }

        public static IServiceCollection AddModularInfrastructure(this IServiceCollection services,IConfiguration config, IList<Assembly> assemblies, IList<IModule> modules, IList<IModuleGuiConnector> moduleGuiConnectors)
        {

            var disabledModules = new List<string>();
            using var scope = services.BuildServiceProvider().CreateScope();
            {

                var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
                foreach (var (key, value) in configuration.AsEnumerable())
                {
                    if (!key.Contains(":module:enabled"))
                    {
                        continue;
                    }
                    if (!bool.Parse(value))
                    {
                        disabledModules.Add(key.Split(":")[0]);
                    }
                }
            }

            services.AddMemoryCache()
                
                .AddModuleInfo(modules)
                .AddModuleRequests(assemblies)
                .AddModuleGuiConnectors(moduleGuiConnectors)
                .AddCommands(assemblies)
                .AddQueries(assemblies)
                .AddEvents(assemblies)
                .AddCaching(assemblies)
                .AddSingleton<IDispatcher, InMemoryDispatcher>()
                .AddMessaging()
                .AddDatabaseOptions()
                .UseQuartz(config)
                .AddControllers().AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
                })
                .ConfigureApplicationPartManager(manager =>
                {

                    var removedParts = new List<ApplicationPart>();
                    foreach (var diabledModule in disabledModules)
                    {

                        var parts = manager.ApplicationParts.Where(x => x.Name.Contains(diabledModule, StringComparison.InvariantCultureIgnoreCase));
                        removedParts.AddRange(parts);
                    }
                    foreach (var part in removedParts)
                    {

                        manager.ApplicationParts.Remove(part);
                    }
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });


            return services;

        }
        public static string GetModuleName(this object value)
            => value?.GetType().GetModuleName() ?? string.Empty;

        public static string GetModuleName(this Type type, string namespacePart = "Modules", int splitIndex = 2)
        {
            if (type?.Namespace is null)
            {
                return string.Empty;
            }

            return type.Namespace.Contains(namespacePart)
                ? type.Namespace.Split(".")[splitIndex].ToLowerInvariant()
                : string.Empty;
        }

        public static void Initialize(this IApplicationBuilder app)
        {

           

        }
    }
}
