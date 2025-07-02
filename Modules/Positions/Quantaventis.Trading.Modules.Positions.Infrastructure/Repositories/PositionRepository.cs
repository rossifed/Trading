using Microsoft.EntityFrameworkCore.Infrastructure;
using Quantaventis.Trading.Modules.Positions.Domain.Model;
using Quantaventis.Trading.Modules.Positions.Domain.Repositories;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Positions.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Infrastructure.Repositories
{
    internal class PositionRepository : IPositionRepository
    {
       private IPositionDao PositionDao { get; }

        public PositionRepository(IPositionDao positionDao)
        {
            PositionDao = positionDao;
        }

        public async Task<IEnumerable<Position>> GetFromInceptionAsync(byte portfolioId, InvestedInstrument investedInstrument)
        {
            IEnumerable<Entities.Position> entities = await PositionDao
                .GetFromInceptionAsync(
                portfolioId, 
                investedInstrument.InstrumentId, 
                investedInstrument.IsSwap);
            return entities.Map();
        }

        public async Task<Position?> GetLastBeforeDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly date)
        {
            Entities.Position? entity = await PositionDao.GetLastBeforeDateAsync(
                portfolioId, 
                investedInstrument.InstrumentId, 
                investedInstrument.IsSwap, date);
            return entity?.Map();
        }

        public async Task UpsertAsync(Position position)
        {
           await  PositionDao.UpsertAsync(position.Map());
        }

        public async Task UpsertRangeAsync(IEnumerable<Position> positions)
        {
            if (positions.Count() > 1000)
                await PositionDao.BulkMergeAsync(positions.Map());
            await PositionDao.UpsertRangeAsync(positions.Map());
        }

        public async Task DeleteAfterDateAsync(byte portfolioId, InvestedInstrument investedInstrument, DateOnly date)
        {
            await PositionDao.DeleteAfterDateAsync(
                portfolioId,
                investedInstrument.InstrumentId,
                investedInstrument.IsSwap, 
                date);
        }

        public async Task<IEnumerable<Position>> GetByPortfolioIdAsOfAsync(byte portfolioId, DateOnly asOfDate)
        {
            var entities = await PositionDao.GetByPortfolioIdAsOfAsync(portfolioId, asOfDate);
            return entities.Map();
        }
        public async Task<DateOnly?> GetMaxPositionDateAsync(byte portfolioId)
        {
            var maxPositionDate = await PositionDao.GetMaxPositionDateAsync(portfolioId);
            return maxPositionDate;
        }
        public async Task<IEnumerable<Position>> GetLastByPortfolioIdAsync(byte portfolioId)
        {
            var entities = await PositionDao.GetLastByPortfolioIdAsync(portfolioId);
            return entities.Map();
        }
    }
}
