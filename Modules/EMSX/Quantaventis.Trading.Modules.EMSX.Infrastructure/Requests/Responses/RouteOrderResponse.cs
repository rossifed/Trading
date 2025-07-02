using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    internal class RouteOrderResponse
    {
        public int EmsxSequence { get; }

        public int RouteId { get; }

        public string Message { get; }

        public RouteOrderResponse(int emsxSequence, int routeId, string message)
        {
            EmsxSequence = emsxSequence;
            RouteId = routeId;
            Message = message;
        }

        public override string? ToString()
            => $"EmsxSequence:{EmsxSequence} Rotue:{RouteId} {Message}";
    }
}
