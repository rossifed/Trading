using Microsoft.Extensions.DependencyInjection;


namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Processors
{
    public static class Extensions
    {

        public static IServiceCollection AddMessageProcessors(this IServiceCollection services)
             => services.AddSingleton<IMiscMessageProcessor, MiscMessageProcessor>()
            .AddSingleton<IResponseMessageProcessor, ResponseMessageProcessor>()
            .AddSingleton<IServiceMessageProcessor, ServiceMessageProcessor>()
            .AddSingleton<ISessionMessageProcessor, SessionMessageProcessor>()
            .AddSingleton<ISubscriptionDataMessageProcessor, SubscriptionDataMessageProcessor>()
            .AddSingleton<ISubscriptionStatusMessageProcessor, SubscriptionStatusMessageProcessor>();
    }
}
