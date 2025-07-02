using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao
{
    internal interface ICalendarDao
    {
        Task<IEnumerable<Calendar>> GetByDateAsync(DateOnly date);
        Task<IEnumerable<Calendar>> GetAsync(DateOnly startDate, DateOnly endDate);

        Task<IEnumerable<Calendar>> GetAllAsync();
    }
    internal class CalendarDao : ICalendarDao
    {
        private InstrumentsDbContext DbContext { get; }

        public CalendarDao(InstrumentsDbContext dbContext)
        {

            this.DbContext = dbContext;
        }
     
 
       

      
        public async Task<IEnumerable<Calendar>> GetByDateAsync(DateOnly date)
        {
           return await DbContext.Calendars
                           .AsNoTracking()
                           .Where(x => x.CalendarDate == date.ToDateTime(TimeOnly.MinValue))
                          
                           .ToListAsync();
        }

        public async Task<IEnumerable<Calendar>> GetAsync(DateOnly startDate, DateOnly endDate)
        {
            return await DbContext.Calendars
            .AsNoTracking()
            .Where(x => x.CalendarDate >= startDate.ToDateTime(TimeOnly.MinValue) && x.CalendarDate <= endDate.ToDateTime(TimeOnly.MinValue))
            .ToListAsync();
        }

        public async Task<IEnumerable<Calendar>> GetAllAsync()
        {
            return await DbContext.Calendars
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
