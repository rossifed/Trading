using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Infrastructure;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Execution.Infrastructure;
using Quantaventis.Trading.Shared.Infrastructure.Scheduling;
using Quantaventis.Trading.Modules.Execution.Api.Services;
using Quartz;
using Quantaventis.Trading.Modules.Execution.Api.Options;
using Quantaventis.Trading.Modules.Execution.Api.QuartzJobs;
using Quantaventis.Trading.Modules.Execution.Api.Clients;
namespace Quantaventis.Trading.Modules.Execution.Api

{
    internal static class Extensions
    {
        public static IServiceCollection AddModule(this IServiceCollection services)
        {
          
            services.AddControllers();
            return services.AddOptions()
                .AddInfrastructure()
                .AddClients()
            .AddServices()
            .AddScheduler();

        }
        private static IServiceCollection AddClients(this IServiceCollection services)
        {
            return services
                .AddScoped<IEmsxClient, EmsxClient>();
        }
        private static IServiceCollection AddOptions(this IServiceCollection services)
        {
            OrderExecutionOptions orderExecutionOptions = services.GetOptions<OrderExecutionOptions>("OrderExecution");
            services.AddSingleton(orderExecutionOptions);
            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
          => services
            .AddScoped<IEmsxOrderExecutionService, EmsxOrderExecutionService>()
            .AddScoped<IEmsxOrderService, EmsxOrderService>();

        private static IServiceCollectionQuartzConfigurator AddQuartzJob<T>(this IServiceCollectionQuartzConfigurator q,
            QuartzSchedulerOptions quartzConfig,
            string jobName
            ) where T : IJob
        {
            var jobKey = new JobKey(jobName);
            q.AddJob<T>(opts => opts.WithIdentity(jobKey));

            QuartzJobOptions jobOptions = quartzConfig.Jobs[jobName];
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity($"{jobName}-trigger")
                //This Cron interval can be described as "run every minute" (when second is zero)
                .WithCronSchedule(jobOptions.CronExpression)
            );
            return q;
        }
        private static IServiceCollection AddScheduler(this IServiceCollection services)
        {
            //QuartzSchedulerOptions quartzConfig = services.GetOptions<QuartzSchedulerOptions>("QuartzConfig");
            //services.AddQuartz(q =>
            //{

            //    q.AddQuartzJob<FetchFillsJob>(quartzConfig, "FetchFillsJob");
            //});

            //// Add Quartz hosted service
            //services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            return services;
        }


    }
}
