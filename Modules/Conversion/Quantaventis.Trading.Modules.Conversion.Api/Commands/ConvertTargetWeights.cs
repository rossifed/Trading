using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Conversion.Api.Dto;
using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.Conversion.Api.Commands
{
    public record ConvertTargetWeights(byte PortfolioId, IEnumerable<TargetWeightDto> TargetWeights) : ICommand;
}
