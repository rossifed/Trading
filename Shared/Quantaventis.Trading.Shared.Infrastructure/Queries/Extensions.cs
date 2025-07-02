using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Quantaventis.Trading.Shared.Abstractions.Queries;
namespace Quantaventis.Trading.Shared.Infrastructure.Queries
{
    public static class Extensions
    {
        public static IServiceCollection AddQueries(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            services.AddSingleton<IQueryDispatcher, QueryDispatcher>();
            services.Scan(s => s.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
