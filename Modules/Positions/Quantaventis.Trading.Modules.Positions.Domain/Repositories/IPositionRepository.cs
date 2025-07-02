using Quantaventis.Trading.Modules.Positions.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Domain.Repositories
{
    internal interface IPositionRepository
    {
        Task<DateOnly?> GetMaxPositionDateAsync(byte portfolioId);
        Task<IEnumerable<Position>> GetFromInceptionAsync(byte portfolioId, InvestedInstrument investedInstrument);
        Task<Position?> GetLastBeforeDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly date);
        Task DeleteAfterDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly date);
        Task<IEnumerable<Position>> GetByPortfolioIdAsOfAsync(byte portfolioId, DateOnly asOfDate);
        Task<IEnumerable<Position>> GetLastByPortfolioIdAsync(byte portfolioId);
        Task UpsertAsync(Position position);
        Task UpsertRangeAsync(IEnumerable<Position> position);

    }
}
