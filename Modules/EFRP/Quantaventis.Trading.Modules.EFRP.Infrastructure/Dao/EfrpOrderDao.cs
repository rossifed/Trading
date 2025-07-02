using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using FlexLabs.EntityFrameworkCore.Upsert;
namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Dao
{
    internal interface IEfrpOrderDao
    {

        Task CreateAsync(IEnumerable<EfrpOrder> entities);

       
    }
    internal class EfrpOrderDao : IEfrpOrderDao
    {
        private EfrpDbContext DbContext { get; }

        public EfrpOrderDao(EfrpDbContext dbContext)
        {

            this.DbContext = dbContext;
        }


        public async Task CreateAsync(IEnumerable<EfrpOrder> entities)
        {
           await DbContext.AddRangeAsync(entities);
            await DbContext.SaveChangesAsync();

        }
    }
}
