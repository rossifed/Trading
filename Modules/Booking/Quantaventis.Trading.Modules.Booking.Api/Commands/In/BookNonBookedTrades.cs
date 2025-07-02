using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Shared.Abstractions.Commands; 

namespace Quantaventis.Trading.Modules.Booking.Api.Commands.In
{
    internal record BookNonBookedTrades():ICommand;
}
