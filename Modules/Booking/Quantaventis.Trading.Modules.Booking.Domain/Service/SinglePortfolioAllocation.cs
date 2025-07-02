using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;

namespace Quantaventis.Trading.Modules.Booking.Domain.Service
{
    internal class SinglePortfolioAllocation : IAllocationRule
    {


        public IEnumerable<RawTradeAllocation> AllocateTrade(RawTrade trade, IEnumerable<OrderAllocation> orderAllocations)
        {
            try
            {
                OrderAllocation orderAllocation = orderAllocations.Single();// expecting only one allocatio or throw an error

                RawTradeAllocation tradeAllocation =  RawTradeAllocation.Create(
                                                        trade.TradeId,
                                                        orderAllocation.PortfolioId,
                                                        trade.Quantity,
                                                        orderAllocation.Quantity,
                                                        orderAllocation.PositionSide);

                return new List<RawTradeAllocation>() { tradeAllocation };
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"A single order allocation was expected, while {orderAllocations.Count()} where found.", e);
            }


        }

    }
}
