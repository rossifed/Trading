using Quantaventis.Trading.Modules.EmsGateway.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API;
using Quantaventis.Trading.Modules.EmsGateway.Api.Options;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Quantaventis.Trading.Modules.EmsGateway.Api.Mappers;
namespace Quantaventis.Trading.Modules.EmsGateway.Api.ACL
{
    internal interface IOrderToEmsxTranslator {
        IEnumerable<EmsxOrder> Translate(IEnumerable<OrderDto> orders);
        EmsxOrder Translate(OrderDto orderDto);
    }
    internal class OrderToEmsxTranslator : IOrderToEmsxTranslator
    {

        private OrderMappingConfig OrderMappingConfig { get; }
      
        public OrderToEmsxTranslator(OrderMappingConfig orderMappingOptions)
        {
            OrderMappingConfig = orderMappingOptions;
        }
        private void MapFields<S, D>(S source, D destination, IEnumerable<FieldMapping> fieldMappings)
        {
            foreach (var mapping in fieldMappings)
            {
                PropertyInfo? sourceProperty = source.GetType().GetProperty(mapping.Source);
                PropertyInfo? destProperty = destination.GetType().GetProperty(mapping.Destination);

                if (sourceProperty != null && destProperty != null)
                {
                  
                    object? sourceValue = sourceProperty.GetValue(source);

                    if (mapping.MapValue)
                    {
                        if (sourceValue != null)
                        {
                            var valueMappingDict = OrderMappingConfig.ValueMappings[mapping.Source];
                            if (valueMappingDict != null)
                            {
                                string? mappedValue;
                                if (valueMappingDict.TryGetValue(sourceValue.ToString(), out mappedValue))
                                {
                                    destProperty.SetValue(destination, ConvertValue(mappedValue, destProperty.PropertyType));
                                }
                            }
                        }
                    }
                    else
                    {
                    
                        destProperty.SetValue(destination, ConvertValue(sourceValue, destProperty.PropertyType));
                    }
                }
            }
        }

        private object? ConvertValue(object? sourceValue, Type targetType)
        {
            if (sourceValue == null)
                return null;

            Type sourceType = sourceValue.GetType();

            // Direct type match handling
            if (sourceType == targetType)
            {
                return sourceValue;
            }

            // Handling for nullable target types
            if (targetType.IsGenericType
                && targetType.GetGenericTypeDefinition() == typeof(Nullable<>)
                && Nullable.GetUnderlyingType(targetType) == sourceType)
            {
                return sourceValue;
            }

            if (targetType == typeof(string))
                return sourceValue.ToString();

            try
            {
                return Convert.ChangeType(sourceValue, targetType);
            }
            catch (InvalidCastException) { }

            // Add more conversion logic if necessary

            throw new InvalidOperationException($"Cannot convert from {sourceType} to {targetType}");
        


    }

        private object? GetValueMapping(string mappingKey, string sourceValue) {
            var valueMappingDict = OrderMappingConfig.ValueMappings[mappingKey];
            if (valueMappingDict != null)
            {
                string? mappedValue;
                if (valueMappingDict.TryGetValue(sourceValue, out mappedValue))
                {
                    return mappedValue;
                }
            }
            return null;
        }
        //public EmsxOrder Translate2(OrderDto orderDto)
        //{
        //    OrderAllocationDto GetAllocation(OrderDto orderDto)
        //    {
        //        if (!orderDto.IsSingleAllocation)//TODO: to be adapted when introducing block orders 
        //            throw new InvalidOperationException($"Order {orderDto.OrderId} cannot be converted to an EMSX Order. A single allocation is supported, but {allocationCount} were provided.");
        //        return orderDto.OrderAllocations.Single();
        //    }
        //    OrderAllocationDto allocation = GetAllocation(orderDto);
        //    EmsxOrder emsxOrder = new EmsxOrder() { 
        //    Account = allocation.TradingAccount,
        //    Amount = allocation.Quantity,
        //    AssetClass = orderDto.InstrumentType,
        //    Broker = orderDto.BrokerCode,
        //    CfdFlag = orderDto.IsCfd,
        //    Exchange= orderDto.Exchange,
        //    HandInstruction= orderDto.HandlingInstruction,
        //    OrderRefId = orderDto.OrderId.ToString(),
        //    Strategy = GetValueMapping("Strategy", orderDto.ExecutionAlgorithm)?.ToString(),
        //    StrategyParameters = orderDto.ExecutionAlgoParams.Select(x=>x.Value).ToArray(),
        //    OrderType = GetValueMapping("OrderType", orderDto.OrderType)?.ToString(),
        //    Ticker =orderDto.Symbol,
        //    TimeInForce = GetValueMapping("TimeInForce", orderDto.TimeInForce)?.ToString(),
        //    TradeDesk=orderDto.TradingDesk,
        //    Notes = orderDto.Notes,
            
        //};
         
        //    return emsxOrder;
        //}

        public EmsxOrder Translate(OrderDto orderDto)
        {
            EmsxOrder emsxOrder = new EmsxOrder();
            void MapAllocation() {
                if (!orderDto.IsSingleAllocation)//TODO: to be adapted when introducing block orders 
                    throw new InvalidOperationException($"Order {orderDto.OrderId} cannot be converted to an EMSX Order. Only single allocation is supported");
                MapFields(orderDto.OrderAllocations.First(), emsxOrder, OrderMappingConfig.AllocationFieldMappings);
            }
            void MapStrategyParams()
            {
                var strategyParams = orderDto.ExecutionAlgoParams.Select(x => x.Value).ToArray();
                emsxOrder.StrategyParameters = strategyParams;
            }
            MapFields(orderDto, emsxOrder, OrderMappingConfig.FieldMappings);
            MapAllocation();
            emsxOrder.StrategyParameters = orderDto.ExecutionAlgoParams.Map();
            var rebalIdStr = orderDto.RebalancingSessionId != null ? orderDto.RebalancingSessionId.ToString() : "";
            emsxOrder.BasketName = $"{orderDto.OrderReason}{rebalIdStr}_{orderDto.TradeDate.ToString("MMdd")}_{orderDto.InstrumentType}";
            emsxOrder.CfdFlag = orderDto.IsCfd ? "1" : "0";
            emsxOrder.Amount = Math.Abs(emsxOrder.Amount);//emsx want only abs value as order quantities and uses side 
            if (orderDto.OrderSide == "S" && orderDto.InstrumentType == "EQU" && orderDto.OrderAllocations.Single().PositionSide == "S")
            {
                emsxOrder.LocateBroker = "MSCO"; //TODO: à l'arrache à 23:00 avant la mise en prod. A corriger ça!!
                emsxOrder.Side = "SHRT";
            }
            return emsxOrder;
        }

    

        public IEnumerable<EmsxOrder> Translate(IEnumerable<OrderDto> orders)
        {
            return orders.Select(x => Translate(x)).ToList();
        }
    }
}
