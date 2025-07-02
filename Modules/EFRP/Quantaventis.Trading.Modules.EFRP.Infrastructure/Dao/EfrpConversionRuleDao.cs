using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;
namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Dao
{
    internal interface IEfrpConversionRuleDao
    {
        Task<IEnumerable<EfrpConversionRule>> GetAllAsync();

        Task SaveAsync(EfrpConversionRule entity);

       
    }
    internal class EfrpConversionRuleDao : IEfrpConversionRuleDao
    {
        private EfrpDbContext DbContext { get; }

        public EfrpConversionRuleDao(EfrpDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<EfrpConversionRule>> GetAllAsync()
        {
            return await DbContext
                 .EfrpConversionRules
                 .AsNoTracking()
                 .Include(x => x.GenericFuture)
                 .Include(x => x.Broker)
                 .ToListAsync();
        }

        public async Task SaveAsync(EfrpConversionRule entity)
        {
           await DbContext.EfrpConversionRules
                .Upsert(entity)
                .On(x=>x.EfrpConversionRuleId)
                .WhenMatched(x=>new EfrpConversionRule() { 
                GenericFutureId = x.GenericFutureId,
                BrokerId= x.BrokerId,
                BaseCurrency= x.BaseCurrency,
                QuoteCurrency= x.QuoteCurrency,
                CmeClearportTicker= x.CmeClearportTicker,
                IsActive = x.IsActive
                })
                .RunAsync();
        }
    }
}
