using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.sq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
namespace Quantaventis.Trading.Shared.Infrastructure.Database
{
    public static class Extensions
    {

        public static IServiceCollection AddDatabaseOptions(this IServiceCollection services)
        {
            var options = services.GetOptions<DatabaseOptions>("database");
            services.AddSingleton(options);
            services.AddSingleton(new UnitOfWorkRegistry());
           
            return services;
        }

        public static IServiceCollection AddDatabase<T>(this IServiceCollection services) where T : DbContext
        {
            var options = services.GetOptions<DatabaseOptions>("database");
            services.AddDbContext<T>(x => x.UseSqlServer(options.ConnectionString));
           // services.AddSingleton(new UnitOfWorkTypeRegistry());

            return services;
        }

        public static IServiceCollection AddUnitOfWork<T>(this IServiceCollection services) where T : class, IUnitOfWork
        {
            services.AddScoped<IUnitOfWork, T>();
            services.AddScoped<T>();
            using var serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetRequiredService<UnitOfWorkRegistry>().Register<T>();

            return services;
        }
    }
}
