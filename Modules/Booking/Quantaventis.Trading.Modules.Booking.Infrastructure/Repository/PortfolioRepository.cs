using Quantaventis.Trading.Modules.Booking.Domain.Model;
using Quantaventis.Trading.Modules.Booking.Domain.Repositories;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Mappers;
using Entities= Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
using System.Reflection.Metadata.Ecma335;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class PortfolioRepository : IPortfolioRepository
    {
        private IPortfolioDao PortfolioDao { get; }

        public PortfolioRepository(IPortfolioDao portfolioDao)
        {
            PortfolioDao = portfolioDao;
        }

        public async Task<Portfolio?> GetByIdAsync(int portfolioId)
        {
            Entities.Portfolio? entity = await PortfolioDao.GetByIdAsync(portfolioId);
            return entity?.Map();
        }
    }
}
