using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Quantaventis.Trading.Shared.Abstractions.Commands;
namespace Quantaventis.Trading.Modules.EFRP.Api.Commands
{
    internal record ImportMsTradeAffirm(byte PortfolioId,string FilePath) : ICommand;

}
