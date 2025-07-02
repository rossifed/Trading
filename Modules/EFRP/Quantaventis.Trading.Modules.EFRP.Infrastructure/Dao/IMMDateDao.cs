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
    internal interface IIMMDateDao
    {
        Task<IEnumerable<Immdate>> GetAllAsync();
       
    }
    internal class IMMDateDao : IIMMDateDao
    {
        private EfrpDbContext DbContext { get; }

        public IMMDateDao(EfrpDbContext dbContext)
        {

            this.DbContext = dbContext;
        }

        public async Task<IEnumerable<Immdate>> GetAllAsync()
        {
            return await DbContext
                 .Immdates
                 .AsNoTracking()
                 .ToListAsync();
        }

    }
}
