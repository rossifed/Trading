using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Infrastructure.Entities;
using Quantaventis.Trading.Shared.Infrastructure.Database;
namespace Quantaventis.Trading.Modules.Instruments.Infrastructure
{
    internal class InstrumentsUnitOfWork : UnitOfWork<InstrumentsDbContext>
    {
        public InstrumentsUnitOfWork(InstrumentsDbContext dbContext) : base(dbContext)
        {
        }
    }
}
