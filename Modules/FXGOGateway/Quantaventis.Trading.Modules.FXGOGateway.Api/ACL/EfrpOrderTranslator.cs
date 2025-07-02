using Quantaventis.Trading.Modules.FXGOGateway.Api.Dto;
using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.ACL
{
    internal class EfrpOrderTranslator : AbstractOrderTranslator, IOrderTranslator<EfrpOrderDto>
    {
        public FxemOrder Translate(EfrpOrderDto dto)
        {
            var currencyPair = $"{dto.BaseCurrency}{dto.QuoteCurrency}";
            return new FxemOrder()
            {
                Instrument = GetInstrument(),
                CurrencyPair = currencyPair,
                Currency = dto.BaseCurrency =="USD"? dto.QuoteCurrency: dto.BaseCurrency,
                Amount = Math.Abs(dto.Quantity),
                Side = GetOrderSide(dto.Quantity),
                ValueDate = dto.ValueDate,
                Account = dto.TradingAccount,
                PortfolioId = dto.PortfolioId,
                RebalancingId = dto.RebalancingId,
                PositionSide = dto.PositionSide

            };
        }

        public IEnumerable<FxemOrder> Translate(IEnumerable<EfrpOrderDto> orders)
          => orders.Select(x => Translate(x)).ToList();

    }
}
