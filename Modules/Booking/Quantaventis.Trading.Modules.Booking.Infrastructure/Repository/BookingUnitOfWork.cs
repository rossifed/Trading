using Quantaventis.Trading.Modules.Booking.Infrastructure.Entities;
using Quantaventis.Trading.Shared.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Booking.Infrastructure.Repository
{
    internal class BookingUnitOfWork : UnitOfWork<BookingDbContext>
    {
        public BookingUnitOfWork(BookingDbContext dbContext) : base(dbContext)
        {
        }
    }
}
