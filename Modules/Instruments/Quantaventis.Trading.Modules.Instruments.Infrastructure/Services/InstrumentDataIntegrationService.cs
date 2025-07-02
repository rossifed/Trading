using Microsoft.EntityFrameworkCore;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Dao;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Infrastructure.Services
{
    internal interface IInstrumentDataIntegrationService {

        Task UpdateInstrumentData();
    }
    internal class InstrumentDataIntegrationService : IInstrumentDataIntegrationService
    {
        private InstrumentsDbContext DbContext { get; }

        public InstrumentDataIntegrationService(InstrumentsDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public async Task UpdateAllRefData()
        {
            var sql = "EXEC [instr].[spMergeAllRefData]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }
        public async Task PropagateUpdateInstruments()
        {
            var sql = "EXEC [instr].[spPropagateUpdateInstruments]";

            await DbContext.Database.ExecuteSqlRawAsync(sql);
        }

        public async Task UpdateInstrumentData()
        {
            await UpdateAllRefData();
            await PropagateUpdateInstruments();
        }
    }
}
