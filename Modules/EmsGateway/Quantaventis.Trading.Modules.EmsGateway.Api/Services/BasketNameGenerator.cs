using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Api.Services
{
    internal interface IBasketNameGenerator { 
        string GenerateBasketName(OrderDto order);
    }
    internal class BasketNameGenerator : IBasketNameGenerator
    {
        public BasketNameGenerator() { }
        public string GenerateBasketName(OrderDto order)
        => $"{order.OrderReason}{order.RebalancingSessionId}_{order.TradeDate.ToString("yyyyMMdd")}_{order.InstrumentType}";
    }
}
