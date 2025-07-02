using Quantaventis.Trading.Modules.Orders.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Services
{
    internal static class OrderAggregator
    {


        internal static IEnumerable<Order> Aggregate(this IEnumerable<Order> orders)
           => orders
            .Where(order=> order.IsSingleAllocation())// only aggregate single legs
            .ToLookup(x => x.GetBlockInfo())
            .Select(x => new Order(
                x.Key,
                x.Select(y => y.OrderAllocations.Single())))
            .Union(orders.Where(order => !order.IsSingleAllocation()))// add already aggregated orders. ensure idempotence
            .ToList();


    }
}
