using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Quantaventis.Trading.Shared.Infrastructure.Scheduling
{
    public static class Extensions
    {

        public static IServiceCollection AddScheduledTask<TJob>(this IServiceCollection services) where TJob : class, IScheduledTask
        {
            var sectionName = $"ScheduledTasks:{typeof(TJob).Name}";
            var jobOptions = services.GetOptions<ScheduledTaskOptions>(sectionName);
            return services.AddScheduledTask<TJob>(jobOptions);
        }
        public static IServiceCollection AddScheduledTask<TJob>(this IServiceCollection services, ScheduledTaskOptions options) where TJob : class, IScheduledTask
        {
            services.AddTransient<TJob>();

            services.AddQuartz(q =>
            {
                var jobKey = new JobKey(typeof(TJob).Name);
                q.AddJob<QuartJobAdapter<TJob>>(opts => opts.WithIdentity(jobKey));
                q.AddTrigger(opts => opts
                    .ForJob(jobKey)
                    .WithIdentity($"{typeof(TJob).Name}-trigger")
                    .WithCronSchedule(options.CronExpression));
            });

            return services;
        }

        public static IServiceCollection UseQuartz(this IServiceCollection services, IConfiguration configuration)
        {
            bool isQuartzEnabled = configuration.GetValue<bool>("Quartz:Enabled");

            if (isQuartzEnabled)
            {

                services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
            }

            return services;
        }
    }
}
