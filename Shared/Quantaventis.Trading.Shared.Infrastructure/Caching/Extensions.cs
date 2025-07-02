using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Caching;

namespace Quantaventis.Trading.Shared.Infrastructure.Caching
{
    internal static class Extensions
    {

        public static IServiceCollection AddCaching(this IServiceCollection services, IEnumerable<Assembly> assemblies) {

            services.Scan(s => s.FromAssemblies(assemblies)
                .AddClasses(c => c.AssignableTo(typeof(ICache<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());


            return services;

        }
    }
}
