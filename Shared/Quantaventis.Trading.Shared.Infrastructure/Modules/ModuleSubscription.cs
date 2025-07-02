using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Shared.Infrastructure.Modules
{
    internal class ModuleSubscription
    {
        public ModuleSubscription(Type subscriptionType, Func<object, CancellationToken, Task> action)
        {
            SubscriptionType = subscriptionType;
            Action = action;
        }
        public Type SubscriptionType { get; }

        public Func<object, CancellationToken, Task> Action { get; }

        public string Key => SubscriptionType.Name;
    }
}
