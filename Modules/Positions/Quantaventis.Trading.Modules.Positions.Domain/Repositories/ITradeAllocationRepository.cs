using Quantaventis.Trading.Modules.Positions.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Domain.Repositories
{
    internal interface ITradeAllocationRepository
    {

        Task<IEnumerable<TradeAllocation>> GetAllByPortfolioIdFromDateAsync(byte portfolioId, DateOnly fromDate);

        Task<IEnumerable<TradeAllocation>> GetByTradeIdAsync(int tradeId);
        Task<IEnumerable<TradeAllocation>> GetFromInceptionAsync(byte portfolioId, InvestedInstrument investedInstrument);

        Task<IEnumerable<TradeAllocation>> GetFromDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly fromTradeDate);
        Task RemoveAsync(int tradeAllocationId);

        Task UpsertAsync(TradeAllocation tradeAllocation);
        Task UpsertRangeAsync(IEnumerable<TradeAllocation> tradeAllocations);

    }
}
