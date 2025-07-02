using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Domain.Repositories
{
    internal interface IBookedTradeRepository
    {
        Task<BookedTrade> AddAsync(BookedTrade trade);
        Task RemoveAsync(int tradeId);
        Task UpdateAsync(BookedTrade trade);
        Task UpsertAsync(BookedTrade trade);
        Task<BookedTrade?> GetByTradeAllocationId(int tradeAllocationId);
        Task<BookedTrade?> GetByTradeId(int tradeId);
        Task<IEnumerable<BookedTrade>> GetByTradeDate(DateOnly tradeDate);
        Task<IEnumerable<BookedTrade>> GetByInstrumentId(int instrumentId);
        Task<IEnumerable<BookedTrade>> GetByBookingDate(DateOnly bookingDate);

    }
}
