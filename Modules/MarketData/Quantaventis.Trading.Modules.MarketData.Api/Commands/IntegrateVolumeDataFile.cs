using Quantaventis.Trading.Shared.Abstractions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.MarketData.Api.Commands
{
    internal record IntegrateVolumeDataFile(string AzureBlobFile) : ICommand;
}
