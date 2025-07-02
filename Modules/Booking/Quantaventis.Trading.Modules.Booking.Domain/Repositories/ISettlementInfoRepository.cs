using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Booking.Domain.Model;
namespace Quantaventis.Trading.Modules.Booking.Domain.Repositories
{
    internal interface ISettlementInfoRepository
    {

        Task<SettlementInfo?> GetByCounterpartyAndInstrumentAsync(int counterparty, int instrumentId, bool isSwap);
        
    }
}
