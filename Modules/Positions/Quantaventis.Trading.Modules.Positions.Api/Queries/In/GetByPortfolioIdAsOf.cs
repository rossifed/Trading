using Quantaventis.Trading.Modules.Positions.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Positions.Api.Queries.In
{
   internal record GetByPortfolioIdAsOf(byte PortfolioId, DateOnly AsOfDate): IQuery<IEnumerable<PositionDto>>;
}
