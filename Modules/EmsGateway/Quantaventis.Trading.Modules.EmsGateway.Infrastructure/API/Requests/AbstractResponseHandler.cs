using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Message = Bloomberglp.Blpapi.Message;
using Name = Bloomberglp.Blpapi.Name;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public abstract class AbstractResponseHandler<RequestType, ResponseType> : IResponseEventHandler<ResponseType> where RequestType : IRequest<ResponseType>
    {
        private TaskCompletionSource<ResponseType> TaskCompletionResult;

        public Name MessageType { get; }
        private int ResponseTimeOut { get; }

        private IEmsxEventHandler MessageEventDispatcher;
        public CorrelationID RequestId => Request.CorrelationID;
        protected RequestType Request;

        public AbstractResponseHandler(IEmsxEventHandler messageEventDispatcher, RequestType request, string responseMessageType, int responseTimeOut = 0)
        {
            this.MessageEventDispatcher = messageEventDispatcher;
            this.TaskCompletionResult = new TaskCompletionSource<ResponseType>();
            Subscribe();
            this.Request = request;
            this.MessageType = new Name(responseMessageType);
            this.ResponseTimeOut = responseTimeOut;


        }
        public AbstractResponseHandler(IEmsxEventHandler messageEventDispatcher, RequestType request, int responseTimeOut = 0): this(messageEventDispatcher, request, request.RequestType, responseTimeOut)
        {
        
        }

        public void Handle(Message msg)
        {
            if (msg.MessageType.Equals(MessageType) && msg.CorrelationID.Equals(Request.CorrelationID))
            {
                TaskCompletionResult.SetResult(CreateResponse(msg));

                Unsubscribe();
            }
        }
        private void Subscribe()
        {
            this.MessageEventDispatcher.ResponseMessageEvent += Handle;
            this.MessageEventDispatcher.ErrorEvent += Handle;
        }
        private void Unsubscribe() {
            this.MessageEventDispatcher.ResponseMessageEvent -= Handle;
            this.MessageEventDispatcher.ErrorEvent -= Handle;
        }
        public void Handle(EmsxApiException exception)
        {
            Unsubscribe();
            TaskCompletionResult.TrySetException(exception);
                
        }
        protected abstract ResponseType CreateResponse(Message msg);
     
        public async Task<ResponseType> GetResponseAsync()
        {
            if (ResponseTimeOut > 0)
            {
                var delayTask = Task.Delay(TimeSpan.FromSeconds(ResponseTimeOut));  // Change the timeout duration as needed
                var completedTask = await Task.WhenAny(TaskCompletionResult.Task, delayTask);

                if (completedTask == delayTask)
                {
                    Unsubscribe();
                    // Timeout logic here
                    TaskCompletionResult.TrySetException(new TimeoutException($"{MessageType} {RequestId}:The operation timed out."));
                }
            }

            return await TaskCompletionResult.Task;
            
        }

        public ResponseType GetResponse()
         => TaskCompletionResult.Task.Result;
    }
}
