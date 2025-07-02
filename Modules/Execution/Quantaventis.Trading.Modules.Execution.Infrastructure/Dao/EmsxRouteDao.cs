using Quantaventis.Trading.Modules.Execution.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Quantaventis.Trading.Modules.Execution.Infrastructure.Dao
{
    internal interface IEmsxRouteDao
    {
        Task UpsertAsync(IEnumerable<EmsxRoute> entities);
        Task UpsertAsync(EmsxRoute entity);
    }
    internal class EmsxRouteDao : IEmsxRouteDao
    {
        private ExecutionDbContext DbContext { get; }

        public EmsxRouteDao(ExecutionDbContext dbContext)
        {
            this.DbContext = dbContext;
        }


        public async Task UpsertAsync(IEnumerable<EmsxRoute> entities)
        {
            await DbContext.UpsertRange(entities)
                .On(x => new { x.Sequence, x.RouteId })
                .RunAsync();
        }

        public async Task UpsertAsync(EmsxRoute entity)
        {
            await DbContext.Upsert(entity)
               .On(x => new { x.Sequence, x.RouteId })
               .RunAsync();
        }
    }
}
