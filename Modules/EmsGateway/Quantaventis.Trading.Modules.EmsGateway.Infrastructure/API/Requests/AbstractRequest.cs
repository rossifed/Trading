using Bloomberglp.Blpapi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public abstract class AbstractRequest<T> : IRequest<T>
    {

        public CorrelationID CorrelationID { get; }
        public string RequestType { get; }


        public AbstractRequest(string requestType)
        {
            this.RequestType = requestType;
            this.CorrelationID = new CorrelationID();
        }

        public Request CreateRequest(Service service)
        {
            Request emsxRequest = service.CreateRequest(RequestType);
            return BuildRequest(emsxRequest);
        }
        protected abstract Request BuildRequest(Request request);
        public abstract IResponseEventHandler<T> CreateResponseHandler(IEmsxEventHandler messageEventDispatcher);

        public override bool Equals(object? obj)
        {
            return obj is AbstractRequest<T> request &&
                   EqualityComparer<CorrelationID>.Default.Equals(CorrelationID, request.CorrelationID) &&
                   RequestType == request.RequestType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(CorrelationID, RequestType);
        }

        public override string? ToString()
        {
            return $"{RequestType}: {CorrelationID}";
        }
    }
}
