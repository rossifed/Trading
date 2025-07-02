using Quantaventis.Trading.Modules.Booking.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Domain.Repositories
{
    internal interface IPortfolioRepository
    {

        Task<Portfolio?> GetByIdAsync(int portfolioId);
    }
}
