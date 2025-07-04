using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Shared.Infrastructure.Commands
{
    public static class Extensions
    {
        public static IServiceCollection AddCommands(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.Scan(s => s.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
