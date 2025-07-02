using Azure.Core;
using static Bloomberglp.Blpapi.Schema;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class ModifyOrderResponse
    {

        public int EmsxSequence { get; }

        public string Message { get; }
        public ModifyOrderRequest Request{get;}
        public ModifyOrderResponse(int emsxSequence, string message, ModifyOrderRequest request)
        {
            EmsxSequence = emsxSequence;
            Message = message;
            Request = request;
        }

        public override string? ToString()
          => $"{EmsxSequence} {Message} {Request}";

    }
}
