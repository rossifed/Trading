using Quantaventis.Trading.Modules.Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Domain.Repositories
{
    internal interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetByInstrumentAndTradeDateAsync(int instrumentId, DateOnly tradeDate);
        Task<Order?> GetByOrderIdAsync(int orderId);
        Task UpsertRangeAsync(IEnumerable<Order> orders);

    }
}
