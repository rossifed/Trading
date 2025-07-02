using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Abstractions.Events;
namespace Quantaventis.Trading.Shared.Infrastructure.Events
{
    internal static class Extensions
    {

        public static IServiceCollection AddEvents(this IServiceCollection services, IList<Assembly> assemblies) {

            services.AddSingleton<IEventDispatcher, EventDispatcher>();
            services.Scan(service => service.FromAssemblies(assemblies)
            .AddClasses(@class => @class.AssignableTo(typeof(IEventHandler<>)))
           // .WithoutAttribute<DecoratorAttribute>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
            return services;
        }
    }
}
