using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Dao
{
    internal interface IFxRateDao
    {
        Task<FxRate?> GetLastAsOfDateAsync(string baseCurrency, string quoteCurrency, DateTime date);
    }

    internal class FxRateDao : IFxRateDao
    {
        private BookingDbContext DbContext { get; }

        public FxRateDao(BookingDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<FxRate?> GetLastAsOfDateAsync(string baseCurrency, string quoteCurrency, DateTime date)
        { 
           return  await DbContext
              .FxRates           
              .AsNoTracking()             
              .Where(x => x.Date <=date && x.BaseCurrency ==baseCurrency && x.QuoteCurrency ==quoteCurrency)
              .OrderByDescending(x => x.Date)
              .FirstOrDefaultAsync();
        }
    }
}
