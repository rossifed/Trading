using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Subscriptions
{
    public abstract class AbstractSubscriptionEventHandler<ResponseType> : ISubscriptionEventHandler<ResponseType>
    {

        private TaskCompletionSource<IEnumerable<ResponseType>> TaskCompletionResult;
        public CorrelationID SubscriptionId { get; }
        Action<CorrelationID, ResponseType>? OnSubscriptionEventAction { get; }
        private IEmsxEventHandler MessageEventDispatcher { get; }

        private IList<ResponseType> Responses { get; }
        public AbstractSubscriptionEventHandler(CorrelationID correlationID, IEmsxEventHandler messageEventDispatcher, Action<CorrelationID, ResponseType>? onSubscriptionEventAction)
        {
            this.SubscriptionId = correlationID;
            this.MessageEventDispatcher = messageEventDispatcher;
            this.TaskCompletionResult = new TaskCompletionSource<IEnumerable<ResponseType>>();
            this.Responses = new List<ResponseType>();
            if (onSubscriptionEventAction != null)
                this.OnSubscriptionEventAction += onSubscriptionEventAction;


            this.MessageEventDispatcher.SubscriptionMessageEvent += Handle;
            this.MessageEventDispatcher.InitialPaintEndEvent += SetResult;

        }
        public void SubscriptionTerminated(CorrelationID correlationId)
        {
            if (SubscriptionId == correlationId)
            {
                MessageEventDispatcher.SubscriptionMessageEvent -= Handle;
            }
        }

        public void SetResult(CorrelationID correlationID)
        {
            if (correlationID == SubscriptionId)
            {
                TaskCompletionResult.SetResult(Responses);
                this.MessageEventDispatcher.InitialPaintEndEvent -= SetResult;
            }
        }


        protected abstract ResponseType CreateResponse(Message msg);
        public void Handle(Message msg)
        {

            if (msg.CorrelationID == SubscriptionId)
            {
                ResponseType response = CreateResponse(msg);
                Responses.Add(response);
                if (OnSubscriptionEventAction != null)
                    OnSubscriptionEventAction(msg.CorrelationID, response);
            }

        }

        public async Task<IEnumerable<ResponseType>> GetResponseAsync()
            => await TaskCompletionResult.Task;

        public IEnumerable<ResponseType> GetResponse()
            => TaskCompletionResult.Task.Result;


    }
}
