using Quantaventis.Trading.Modules.EFRP.Domain.Model;
using Quantaventis.Trading.Modules.EFRP.Domain.Repositories;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Dao;
using Quantaventis.Trading.Modules.EFRP.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Repositories
{
    internal class IMMDateRepository : IIMMDateRepository
    {
        private IIMMDateDao IMMDateDao { get;}

        public IMMDateRepository(IIMMDateDao iMMDateDao)
        {
            IMMDateDao = iMMDateDao;
        }

        public async Task<IEnumerable<DateOnly>> GetAllAsync()
        {
            var entities = await IMMDateDao.GetAllAsync();
            return entities.Select(x=>DateOnly.FromDateTime(x.Date));
        }

      
    }
}
