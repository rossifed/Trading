using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Domain.Repositories
{
    internal interface IRawTradeRepository
    {
        Task UpdateAsync(RawTrade trade);
        Task<RawTrade> CreateAsync(RawTrade trade);
        Task<RawTrade?> GetByEmsxOrderId(int emsxOrderId);

        Task<RawTrade?> GetByTradeId(int tradeId);
        Task<IEnumerable<RawTrade>> GetNonBookedAsync();
        Task<RawTrade> UpsertByEmsxOrderIdAsync(RawTrade trade);

        Task<RawTrade> UpsertByOrderRefIdAsync(RawTrade trade);
    }
}
