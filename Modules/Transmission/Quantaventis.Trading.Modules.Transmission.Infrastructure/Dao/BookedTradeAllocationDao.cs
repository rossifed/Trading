using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Dao
{
    internal interface IBookedTradeAllocationDao {
        Task UpsertAsync(BookedTradeAllocation bookedTradeAllocation);

        Task UpsertRangeAsync(IEnumerable<BookedTradeAllocation> bookedTradeAllocations);

    }
    internal class BookedTradeAllocationDao : IBookedTradeAllocationDao
    {

        private TransmissionDbContext DbContext { get; }

        public BookedTradeAllocationDao(TransmissionDbContext dbContext)
        {

            this.DbContext = dbContext;
        }




        public async Task UpsertAsync(BookedTradeAllocation entity)
        {
            await DbContext
              .Upsert(entity)
              .On(x => new { x.TradeAllocationId })
              .RunAsync();
        }

        public async Task UpsertRangeAsync(IEnumerable<BookedTradeAllocation> entities)
        {

            await DbContext
                .UpsertRange(entities)
                .On(x => new { x.TradeAllocationId })
                .RunAsync();

        }
    }
}
