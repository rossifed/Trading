using Quantaventis.Trading.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Instruments.Api.Dto;
namespace Quantaventis.Trading.Modules.Instruments.Api.Queries.In
{
    internal record GetAllInstruments() : IQuery<IEnumerable<InstrumentDto>> { }

}
