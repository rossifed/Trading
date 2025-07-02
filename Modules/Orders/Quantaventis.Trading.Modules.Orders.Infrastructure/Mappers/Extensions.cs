using Quantaventis.Trading.Modules.Orders.Domain.Model;


namespace Quantaventis.Trading.Modules.Orders.Infrastructure.Mappers
{
    internal static class Extensions
    {
        internal static IEnumerable<Entities.Order> Map(this IEnumerable<Order> blockOrders)
        {
            return blockOrders.Select(x => x.Map()).ToList();
        }
        internal static IEnumerable<Order> Map(this IEnumerable<Entities.Order> entities)
        {
            return entities.Select(x => x.Map());
        }
        internal static Entities.Order Map(this Order order)
        {
             void SetOrderFromAlgoParams(Entities.Order entity, ExecutionAlgoParam[] algoParams)
            {
                for (int i = 0; i <= algoParams.Count()-1; i++)
                {
                    var paramProperty = entity.GetType().GetProperty($"Param{i+1}");
                    var valueProperty = entity.GetType().GetProperty($"Value{i+1}");

                    var algoParam = algoParams[i];

                    if (algoParam != null)
                    {
                        paramProperty?.SetValue(entity, algoParam.Parameter);
                        valueProperty?.SetValue(entity, algoParam.Value);
                    }
                }
            }

            var entity = new Entities.Order()
            {

                OrderId = order.OrderId,
                RebalancingSessionId = order.RebalancingSessionId,
                InstrumentId = order.InstrumentId,
                BrokerId = order.Broker.Id,
                Quantity = order.Quantity,
                TradeDate = order.TradeDate.ToDateTime(TimeOnly.MinValue),
                OrderTypeId = order.OrderType.Id,
                TimeInForceId = order.TimeInForce.Id,
                TradingDeskId =order.TradingDesk.Id,
                ExecutionAlgorithmId = order.ExecutionAlgorithm.Id,
                ExecutionChannelId = order.ExecutionChannel.Id, 
                HandlingInstructionId = order.HandlingInstruction.Id,
                TradeModeId = order.TradeMode.Id,
                OrderSideId = order.OrderSide.Id,
                OrderReason = order.OrderReason.Mnemonic



            };
            SetOrderFromAlgoParams(entity, order.ExecutionAlgoParams.ToArray());
            order.OrderAllocations.ToList().ForEach(x => entity.OrderAllocations.Add(x.Map()));
            return entity;
        }
        internal static Order Map(this Entities.Order entity)
        {
            return new Order(entity.OrderId,
                entity.RebalancingSessionId,
                entity.Instrument.Map(),
                entity.OrderSide.Map(),
               entity.OrderType.Map(),
               entity.TimeInForce.Map(),
               entity.HandlingInstruction.Map(),
               entity.ExecutionAlgorithm.Map(),
               entity.MapAlgoParams(),
               entity.ExecutionChannel.Map(),
               entity.TradingDesk.Map(),
               DateOnly.FromDateTime(entity.TradeDate),
               entity.Broker.Map(),
               entity.TradeMode.Map(),
               OrderReason.FromMnemonic(entity.OrderReason),
               entity.OrderAllocations.Map()
               );
        }
        internal static ExecutionProfile Map(this Entities.ExecutionProfile entity)
        {

            return new ExecutionProfile(entity.ExecutionProfileId,
                 entity.OrderType.Map(),
                entity.TimeInForce.Map(),
                 entity.HandlingInstruction.Map(),
                entity.ExecutionAlgorithm.Map(),
               entity.ExecutionAlgorithmParamSet.Map(),
               entity.ExecutionChannel.Map(),
               entity.TradingDesk.Map());
        }
        internal static ExecutionChannel Map(this Entities.ExecutionChannel entity)
        {

            return new ExecutionChannel(entity.ExecutionChannelId,
                 entity.Mnemonic);
        }
        internal static TradingDesk Map(this Entities.TradingDesk entity)
        {

            return new TradingDesk(entity.TradingDeskId,
                 entity.Code);
        }
        internal static TradeMode Map(this Entities.TradeMode entity)
        {

            return new TradeMode(entity.TradeModeId,
                 entity.Mnemonic);
        }
        internal static IEnumerable<Portfolio> Map(this IEnumerable<Entities.Portfolio> portfolios)
        {
            return portfolios.Select(x => x.Map()).ToList();
        }
        internal static Portfolio Map(this Entities.Portfolio entity)
        {

            return new Portfolio(entity.PortfolioId,
                 entity.Mnemonic);
        }

        internal static IEnumerable<ExecutionAlgoParam> MapAlgoParams(this Entities.Order entity)
        {
            List<ExecutionAlgoParam> parameters = new List<ExecutionAlgoParam>();

            if (entity != null)
            {

                void CheckAndAddParam(string? param, string? value)
                {
                    if (param != null)
                        parameters.Add(new ExecutionAlgoParam(param, value));
                }
                CheckAndAddParam(entity.Param1, entity.Value1);
                CheckAndAddParam(entity.Param2, entity.Value2);
                CheckAndAddParam(entity.Param3, entity.Value3);
                CheckAndAddParam(entity.Param4, entity.Value4);
                CheckAndAddParam(entity.Param5, entity.Value5);
                CheckAndAddParam(entity.Param6, entity.Value6);
                CheckAndAddParam(entity.Param7, entity.Value7);
                CheckAndAddParam(entity.Param8, entity.Value8);
            }
            return parameters;
        }
        internal static IEnumerable<ExecutionAlgoParam> Map(this Entities.ExecutionAlgorithmParamSet? entity)
        {
            List<ExecutionAlgoParam> parameters = new List<ExecutionAlgoParam>();

            if (entity != null)
            {

                void CheckAndAddParam(string? param, string? value)
                {
                    if (param != null)
                        parameters.Add(new ExecutionAlgoParam(param, value));
                }
                CheckAndAddParam(entity.Param1, entity.Value1);
                CheckAndAddParam(entity.Param2, entity.Value2);
                CheckAndAddParam(entity.Param3, entity.Value3);
                CheckAndAddParam(entity.Param4, entity.Value4);
                CheckAndAddParam(entity.Param5, entity.Value5);
                CheckAndAddParam(entity.Param6, entity.Value6);
                CheckAndAddParam(entity.Param7, entity.Value7);
                CheckAndAddParam(entity.Param8, entity.Value8);
            }
            return parameters;
        }


        internal static HandlingInstruction Map(this Entities.HandlingInstruction entity)
        {

            return new HandlingInstruction(entity.HandlingInstructionId,
                    entity.Code,
                    entity.Description);
        }

        private static IEnumerable<OrderAllocation> Map(this IEnumerable<Entities.OrderAllocation> orderAllocations)
        {
            return orderAllocations.Select(x => x.Map()).ToList();
        }
        private static OrderAllocation Map(this Entities.OrderAllocation entity)
        {
            return new OrderAllocation(entity.Portfolio.Map(), entity.TradingAccount.Map(), entity.Quantity, entity.PositionSide.Map());

        }
        private static PositionSide Map(this Entities.PositionSide entity)
        {
            return PositionSide.FromMnemonic(entity.Mnemonic);

        }
        private static OrderSide Map(this Entities.OrderSide entity)
        {
            return OrderSide.FromMnemonic(entity.Mnemonic);

        }
        internal static IEnumerable<Entities.OrderAllocation> Map(this IEnumerable<OrderAllocation> orderAllocations)
        {
            return orderAllocations.Select(x => x.Map()).ToList();
        }
        internal static Entities.OrderAllocation Map(this OrderAllocation orderAllocation)
        {
            return new Entities.OrderAllocation()
            {
                PortfolioId = orderAllocation.Portfolio.Id,
                TradingAccountId = orderAllocation.TradingAccount.Id,
                Quantity = orderAllocation.Quantity,
                PositionSideId = orderAllocation.PositionSide.Id

            };
        }
        internal static IEnumerable<Instrument> Map(this IEnumerable<Entities.Instrument> entities)
        {
            return entities.Select(x => x.Map()).ToList();
        }
        internal static Instrument Map(this Entities.Instrument entity)
        {
            return new Instrument(
                entity.InstrumentId,
                entity.Symbol,
                entity.InstrumentType.Map(),
                entity.ExchangeNavigation?.Map(),
                entity.Maturity.HasValue ? DateOnly.FromDateTime(entity.Maturity.Value) : null,
                entity.GenericFutureId);
        }



        internal static Entities.Instrument Map(this Instrument instrument)
        {
            return new Entities.Instrument()
            {
                InstrumentId = instrument.Id,
                Symbol = instrument.Symbol,
                InstrumentTypeId = instrument.InstrumentType.Id,
                GenericFutureId = instrument.GenericFutureId,       
              
                


            };
        }

        internal static IEnumerable<BrokerSelectionRule> Map(this IEnumerable<Entities.BrokerSelectionRule> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }

        internal static BrokerSelectionRule Map(this Entities.BrokerSelectionRule entity)
        {
            return new BrokerSelectionRule(entity.Portfolio?.Map(),
                entity.InstrumentType?.Map(),
                entity.Broker.Map());

        }

        internal static IEnumerable<BrokerSelectionRuleOverride> Map(this IEnumerable<Entities.BrokerSelectionRuleOverride> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }
        internal static BrokerSelectionRuleOverride Map(this Entities.BrokerSelectionRuleOverride entity)
        {
            return new BrokerSelectionRuleOverride(entity.Portfolio.Map(),
                entity.Instrument.Map(),
                entity.Broker.Map());

        }
        internal static IEnumerable<TradingAccountSelectionRule> Map(this IEnumerable<Entities.TradingAccountSelectionRule> entities)
        {
            return entities.Select(x => x.Map());

        }

        internal static TradingAccountSelectionRule Map(this Entities.TradingAccountSelectionRule entity)
        {
            return new TradingAccountSelectionRule(
                entity.Portfolio.Map(),
                entity.Broker.Map(),
                entity.TradeMode.Map(),
                entity.InstrumentType.Map(),
                entity.TradingAccount.Map());

        }

        internal static IEnumerable<ExecutionProfileSelectionRule> Map(this IEnumerable<Entities.ExecutionProfileSelectionRule> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }


        internal static ExecutionProfileSelectionRule Map(this Entities.ExecutionProfileSelectionRule entity)
        {
            return new ExecutionProfileSelectionRule(
                entity.Portfolio?.Map(),
                entity.Broker?.Map(),
                entity.InstrumentType?.Map(),
                entity.Exchange?.Map(),
                entity.TradeMode.Map(),
                entity.ExecutionProfile.Map());
        }
        internal static IEnumerable<ExecutionProfileSelectionRuleOverride> Map(this IEnumerable<Entities.ExecutionProfileSelectionRuleOverride> entities)
        {
            return entities.Select(x => x.Map()).ToList();

        }
        internal static ExecutionProfileSelectionRuleOverride Map(this Entities.ExecutionProfileSelectionRuleOverride entity)
        {
            return new ExecutionProfileSelectionRuleOverride(
                entity.Portfolio.Map(),
                entity.Broker.Map(),
                entity.Instrument.Map(),
                entity.TradeMode.Map(),
                entity.ExecutionProfile.Map());
        }
        internal static TradeModeSelectionRule Map(this Entities.TradeModeSelectionRule entity)
        {
            return new TradeModeSelectionRule(
                entity.Broker?.Map(),
                entity.Portfolio?.Map(),
                entity.InstrumentType?.Map(),
                entity.IsEfrp,
                entity.TradeMode.Map()
                );

        }

        internal static IEnumerable<TradeModeSelectionRule> Map(this IEnumerable<Entities.TradeModeSelectionRule> entities)
        {
            return entities.Select(x => x.Map());

        }



        internal static ExecutionAlgorithm Map(this Entities.ExecutionAlgorithm entity)
        {
            return new ExecutionAlgorithm(entity.ExecutionAlgorithmId, entity.Mnmemonic, entity.Name);
        }

        internal static TradingAccount Map(this Entities.TradingAccount entity)
        {
            return new TradingAccount(entity.TradingAccountId, entity.Code);
        }
        internal static OrderType Map(this Entities.OrderType entity)
        {
            return new OrderType(entity.OrderTypeId, entity.Mnemonic, entity.Name);
        }
        internal static TimeInForce Map(this Entities.TimeInForce entity)
        {
            return new TimeInForce(entity.TimeInForceId, entity.Mnemonic);
        }

        internal static Broker Map(this Entities.Broker entity)
        {
            return new Broker(entity.BrokerId, entity.Name);
        }
        internal static InstrumentType Map(this Entities.InstrumentType entity)
        {
            return new InstrumentType(entity.InstrumentTypeId, entity.Mnemonic);
        }
        internal static Exchange Map(this Entities.Exchange entity)
        {

            return new Exchange(entity.ExchangeId, entity.Code);
        }
        internal static Entities.Portfolio Map(this Portfolio portfolio)
        {
            return new Entities.Portfolio()
            {
                PortfolioId = portfolio.Id,
                Mnemonic = portfolio.Mnemonic


            };
        }
    }
}
