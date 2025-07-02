using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Domain.Repositories
{
    internal interface ITradeBookingErrorRepository
    {
        Task CreateAsync(TradeBookingError error);

        Task DeleteByTradeIdAsync(int tradeId);
        Task<IEnumerable<TradeBookingError>> GetByTradeIdAsync(int tradeId);

        Task<IEnumerable<TradeBookingError>> GeAllAsync();

    }
}
