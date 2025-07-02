using FluentDateTime;
namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Services
{
    interface ITradeDateResolver
    {
        DateOnly NextTradeDate(TimeOnly tradeDateSwitchTime, DateTime nowUtc);

    }
    internal class TradeDateResolver : ITradeDateResolver
    {


        public TradeDateResolver()
        {

        }

    

        public DateOnly NextTradeDate(TimeOnly tradeDateSwitchTime, DateTime now)
        {


            DateOnly todayDate = DateOnly.FromDateTime(now);
            TimeOnly todayTime = TimeOnly.FromDateTime(now);
            DateOnly nextBusinessDate = DateOnly.FromDateTime(now.AddBusinessDays(1));
            DateOnly tradeDate = tradeDateSwitchTime > todayTime ? todayDate : nextBusinessDate;
            return tradeDate;
        }
    }
}
