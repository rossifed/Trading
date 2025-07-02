using Microsoft.AspNetCore.Server.Kestrel.Transport.Quic;
using Quantaventis.Trading.Modules.FXGOGateway.Api.Dto;
using Quantaventis.Trading.Modules.FXGOGateway.Infrastructure.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.FXGOGateway.Api.ACL
{
    internal class FxForwardOrderTranslator : AbstractOrderTranslator, IOrderTranslator<OrderDto>
    {
        private string ValueDateFormat { get; } = "MM/dd/yyyy";
        private string GetCurrencyPair(OrderDto dto) {
            return dto.Symbol.Replace("/","").Substring(0, 6);//TODO:Realy bad to retrieve the information based on the symbol. 
        }

        private string GetValueDatePart(OrderDto dto)
        {
            return dto.Symbol.Substring(8, ValueDateFormat.Length);//TODO:Realy bad to retrieve the information based on the symbol. 
        }
        private DateOnly GetValueDate(OrderDto dto)
        {
            return DateOnly.ParseExact(GetValueDatePart(dto), 
                ValueDateFormat,
                CultureInfo.InvariantCulture);//TODO:Realy bad to retrieve the information based on the symbol. 
        }
        private string GetBaseCurrency(OrderDto dto)
        {
            return GetCurrencyPair(dto).Substring(0,3);//TODO:Realy bad to retrieve the information based on the symbol. 
        }
        private string GetQuoteCurrency(OrderDto dto)
        {
            return GetCurrencyPair(dto).Substring(3, 3);//TODO:Realy bad to retrieve the information based on the symbol. 
        }

        public FxemOrder Translate(OrderDto dto)
        {

            if (dto.OrderAllocations.Count() != 1)
                throw new InvalidOperationException($"Order {dto.OrderId} can't be translated to FXEM Order. Only single allocation are supported.");
            string quoteCurrency = GetQuoteCurrency(dto);
            string baseCurrency = GetBaseCurrency(dto);
            var orderAllocation = dto.OrderAllocations.First();
            var currency = baseCurrency ;
            if(dto.ContractMaturity == null)
                throw new InvalidOperationException($"Order {dto.OrderId} can't be translated to FXEM Order. The ValueDate can't be null.");

            var valueDate = dto.ContractMaturity.Value;

            return new FxemOrder()
            {
                Instrument = GetInstrument(),
                CurrencyPair = GetCurrencyPair(dto),
                Currency = currency,
                Amount = Math.Abs(dto.Quantity),
                Side = dto.OrderSide,
                ValueDate = valueDate,
                Account = orderAllocation.TradingAccount,
                PortfolioId = orderAllocation.PortfolioId,
                RebalancingId = dto.RebalancingSessionId,
                PositionSide = orderAllocation.PositionSide
            };
        }

        public IEnumerable<FxemOrder> Translate(IEnumerable<OrderDto> orders)
          => orders.Select(x => Translate(x)).ToList();

    }
}
