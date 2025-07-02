using Quantaventis.Trading.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Instruments.Api.Commands
{
    internal record UploadCurrencyPaires(IEnumerable<string> Symbols) : ICommand;
}
