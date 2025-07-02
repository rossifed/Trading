using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Quantaventis.Trading.Shared.Abstractions.Messaging;
using Quantaventis.Trading.Shared.Infrastructure.Messaging;
using Quantaventis.Trading.Shared.Infrastructure.Messaging.Contexts;

namespace Quantaventis.Trading.Shared.Infrastructure.Messaging
{
    internal static class Extensions
    {

        public static IServiceCollection AddMessaging(this IServiceCollection services) {

            services.AddTransient<IMessageBroker, InMemoryMessageBroker>();
            services.AddSingleton<IMessageChannel, MessageChannel>();
            services.AddSingleton<IAsyncMessageDispatcher, AsyncMessageDispatcher>(); 
            services.AddSingleton<IMessageContextProvider, MessageContextProvider>();
            services.AddSingleton<IMessageContextRegistry, MessageContextRegistry>();
            var messagingOptions = services.GetOptions<MessagingOptions>(sectionName: "messaging");
            services.AddSingleton(messagingOptions);
  
            services.AddHostedService<AsyncDispatcherJob>();
          
            return services;

        }
    }
}
