using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Subscriptions
{
    internal abstract class AbstractSubscription : ISubscription
    {
        public CorrelationID SubscriptionId { get; }


        protected AbstractSubscription()
        {
            SubscriptionId = new CorrelationID();
   
        }

        protected abstract string BuildString(string serviceName);
        protected abstract string BuildString(string serviceName, string teamName);
        public bool Match(Message message) => message.CorrelationID == SubscriptionId;
        public void Start(Session session, string serviceName, string teamName)
        {
            session.Subscribe(new List<Subscription>() {
                new Subscription(BuildString(serviceName,teamName), SubscriptionId)

            });
        }
        public void Start(Session session, string serviceName)
        {
            session.Subscribe(new List<Subscription>() {
                new Subscription(BuildString(serviceName), SubscriptionId)

            });
        }
        public void Cancel(Session session)
        {
            session.Cancel(SubscriptionId);
        }

  


    }
    
}
