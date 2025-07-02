using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public static class EventStatus
    {
        public const int HeartBeat = 1;
        public const int InitialPaint = 4;
        public const int NewOrderRoute = 6;
        public const int OrderRouteUpdate = 7;
        public const int OrderRouteDeletion = 8;
        public const int InitialPaintEnd = 11;
    }
}
