//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Dao;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Entities;
//using Quantaventis.Trading.Modules.Portfolios.Infrastructure.Repositories;
//using Quantaventis.Trading.Modules.Portfolios.Domain.Repositories;
//using Quantaventis.Trading.Modules.Weights.Infrastructure.Files;
using Quantaventis.Trading.Modules.Orders.Api.Dto;
using Quantaventis.Trading.Modules.Orders.Domain.Model;
using Entities = Quantaventis.Trading.Modules.Orders.Infrastructure.Entities;


namespace Quantaventis.Trading.Modules.Orders.Api.Mappers
{
    internal static class Extensions
    {
        public static Entities.Portfolio Map(this PortfolioDto dto)
        {
            return new Entities.Portfolio()
            {
                PortfolioId = dto.Id,
                Name = dto.Name,
                Mnemonic = dto.Mnemonic,
                Currency = dto.Currency,

            };
        }

        public static IEnumerable<Entities.Portfolio> Map(this IEnumerable<PortfolioDto> rebalancingOrderDtos)
        {
            return rebalancingOrderDtos.Select(x => x.Map());

        }


        public static IEnumerable<BaseOrderDto> Map(this IEnumerable<RebalancingOrderDto> rebalancingOrderDtos)
        {
            return rebalancingOrderDtos.Select(x => x.Map());

        }
        public static BaseOrderDto Map(this RebalancingOrderDto dto)
        {
            return new BaseOrderDto()
            {
                InstrumentId = dto.InstrumentId,
                PortfolioId = dto.PortfolioId,
                RebalancingSessionId = dto.RebalancingSessionId,
                Quantity = dto.Quantity
            };

        }
        public static Entities.Instrument Map(this InstrumentDto dto)
        {
            return new Entities.Instrument()
            {
                InstrumentId = dto.Id,
                Symbol = dto.Symbol,
                Name = dto.Name,
                InstrumentTypeId = dto.InstrumentTypeId,
                MarketSector = dto.MarketSector,
                Currency = dto.Currency,
                Exchange = dto.Exchange
            };

        }
        //public static Instrument Map(this InstrumentDto dto)
        //{
        //    return new Instrument(dto.Id, dto.Symbol, new InstrumentType(dto.InstrumentTypeId, dto.InstrumentType));

        // }
        public static IEnumerable<OrderDto> Map(this IEnumerable<Order> blockOrders)
        {
            return blockOrders.Select(x => x.Map());

        }
        public static ExecutionProfileDto Map(this ExecutionProfile executionProfile)
        {
            return new ExecutionProfileDto()
            {
                ExecutionAlgoParams = executionProfile.ExecutionAlgoParams.Map(),
                ExecutionAlgorithm = executionProfile.ExecutionAlgorithm.Mnemonic,
                OrderType = executionProfile.OrderType.Mnemonic,
                TimeInForce = executionProfile.TimeInForce.Mnemonic,
                HnadlingInstruction = executionProfile.HandlingInstruction.Code,
                ExecutionChannel = executionProfile.ExecutionChannel.Mnemonic
            };

        }
        public static IEnumerable<ExecutionAlgoParamDto> Map(this IEnumerable<ExecutionAlgoParam> executionAlgoParams)
        {
            return executionAlgoParams.Select(x => x.Map());
        }
        public static ExecutionAlgoParamDto Map(this ExecutionAlgoParam executionAlgoParam)
        {
            return new ExecutionAlgoParamDto()
            {
                Parameter = executionAlgoParam.Parameter,
                Value = executionAlgoParam.Value
            };

        }
        //public static IndividualOrderDto Map(this IndividualOrder individualOrder)
        //{
        //    return new IndividualOrderDto()
        //    {
        //        BlockOrderId = individualOrder.Id,
        //        BrokerId = individualOrder.Broker.Id,
        //        BrokerCode = individualOrder.Broker.Code,
        //        InstrumentId = individualOrder.InstrumentId,
        //        Symbol = individualOrder.Instrument.Symbol,
        //        Quantity = individualOrder.Quantity,
        //        TradeDate = individualOrder.TradeDate,
        //        ExecutionAlgorithm = individualOrder.ExecutionAlgorithm.Mnemonic,
        //        OrderType = individualOrder.OrderType.Mnemonic,
        //        TimeInForce = individualOrder.TimeInForce.Mnemonic,
        //        HandlingInstruction = individualOrder.HandlingInstruction.Code,
        //        TradeMode = individualOrder.TradeMode.Mnemonic,
        //        PortfolioId = individualOrder.Portfolio.Id,
        //        TradingAccount = individualOrder.TradingAccount.Code,
        //        TradingAccountId = individualOrder.TradingAccount.Id,
        //        ExecutionAlgoParams = individualOrder.ExecutionAlgoParams.Map(),

        //    };

        //}


        public static OrderDto Map(this Order order)
        {
            return new OrderDto()
            {
                OrderId = order.OrderId,
                BrokerId = order.Broker.Id,
                BrokerCode = order.Broker.Code,
                InstrumentId = order.InstrumentId,
                Symbol = order.Instrument.Symbol,
                Quantity = order.Quantity,
                TradeDate = order.TradeDate,
                InstrumentType = order.InstrumentType.Mnemonic,
                IsEfrp = order.IsEfrp,
                IsCfd = order.IsCfd,
                TradeMode = order.TradeMode.Mnemonic,
                IsSingleAllocation = order.IsSingleAllocation(),
                OrderAllocations = order.OrderAllocations.Map(),
                RebalancingSessionId = order.RebalancingSessionId,
                ExecutionAlgoParams = order.ExecutionAlgoParams.Map(),
                ExecutionAlgorithm = order.ExecutionAlgorithm.Mnemonic,
                OrderType = order.OrderType.Mnemonic,
                TimeInForce = order.TimeInForce.Mnemonic,
                ContractMaturity = order.ContractMaturity,
                Exchange = order.Instrument.Exchange?.Symbol,
                TradingDesk = order.TradingDesk.Code,
                ExecutionChannel = order.ExecutionChannel.Mnemonic,
                HandlingInstruction = order.HandlingInstruction.Code,
                OrderSide = order.OrderSide.Mnemonic,
                OrderReason = order.OrderReason.Mnemonic,
            };
        }

        public static IEnumerable<OrderRouteDto> MapOrderRoutes(this IEnumerable<Order> orders)
        {
            return orders.Select(x => x.MapOrderRoute());
        }
        public static OrderRouteDto MapOrderRoute(this Order order)
        {
            return new OrderRouteDto()
            {
                OrderId = order.OrderId,
                BrokerCode = order.Broker.Code,
                ExecutionAlgoParams = order.ExecutionAlgoParams.Map(),
                ExecutionAlgorithm = order.ExecutionAlgorithm.Mnemonic,
                ExecutionChannel = order.ExecutionChannel.Mnemonic,
                HandlingInstruction = order.HandlingInstruction.Code,
                OrderType = order.OrderType.Mnemonic,
                Quantity = order.Quantity,
                TimeInForce = order.TimeInForce.Mnemonic,
                TradeMode = order.TradeMode.Mnemonic,
                TradingDesk = order.TradingDesk.Code
            };
        }

        public static OrderAllocationDto Map(this OrderAllocation allocationOrder)
        {
            return new OrderAllocationDto()
            {
                PortfolioId = allocationOrder.Portfolio.Id,
                Quantity = allocationOrder.Quantity,
                TradingAccount = allocationOrder.TradingAccount.Code,
                TradingAccountId = allocationOrder.TradingAccount.Id,
                PositionSide = allocationOrder.PositionSide.Mnemonic
            };
        }
        public static IEnumerable<OrderAllocationDto> Map(this IEnumerable<OrderAllocation> orderAllocations)
        {
            return orderAllocations.Select(x => x.Map());
        }
    }
}
