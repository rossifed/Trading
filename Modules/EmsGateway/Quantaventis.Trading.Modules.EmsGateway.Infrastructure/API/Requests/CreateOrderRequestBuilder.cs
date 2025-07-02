using Bloomberglp.Blpapi;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using CorrelationID = Bloomberglp.Blpapi.CorrelationID;
using Request = Bloomberglp.Blpapi.Request;
using Service = Bloomberglp.Blpapi.Service;
using static Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.EmsxElements;
namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API.Requests
{
    public class CreateOrderRequestBuilder 
    {

        private EmsxOrder Order { get; }
        public CreateOrderRequestBuilder() {//TOOD: no time now
        
        }
        private string Ticker { get; set; }
        private int Amount { get; set; }
        private string OrderType { get; set; }

        private string Tif { get; set; }
        private string HandInstruction { get; set; }
        private string Side { get; set; }
        public CreateOrderRequestBuilder SetTicker(string ticker)
        {
            Ticker = ticker;
            return this;
        }

        public CreateOrderRequestBuilder SetAmount(int amocunt)
        {
            Amount = amocunt;
            return this;
        }
        public CreateOrderRequestBuilder SetOrderType(string orderType)
        {
            OrderType = orderType;
            return this;
        }
        public CreateOrderRequestBuilder SetTif(string tif)
        {
            Tif = tif;
            return this;
        }
        public CreateOrderRequestBuilder SetHandInstruction(string handInstruction)
        {
            HandInstruction = handInstruction;
            return this;
        }
        public CreateOrderRequestBuilder SetSide(string side)
        {
            Side = side;
            return this;
        }
        private bool IsValid() {
            return !string.IsNullOrEmpty(Side);
        }
        //public CreateOrderRequest Build(Action<CreateOrderRequest> complete) {
        //    if (IsValid())
        //    {
        //        var createOrderRequest = new CreateOrderRequest();
        //        complete(createOrderRequest);
        //        return createOrderRequest;
        //    }
        //    throw new InvalidOperationException("Request is not valid. Ensure all mandatory parameters have been set");
        //}

     
    }
}
