using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class Order
    {
        internal int InstrumentId => Instrument.Id;

        internal int Quantity { get; }
        internal int? RebalancingSessionId { get; }
        internal Instrument Instrument { get; }
        internal int OrderId { get; }
        internal DateOnly TradeDate { get; }

        internal Broker Broker { get; }


        internal OrderSide OrderSide { get; }
        internal InstrumentType InstrumentType => Instrument.InstrumentType;
        internal bool IsCfd => TradeMode.TradeAsCFD;

        internal bool IsEfrp => TradeMode.TradeAsEfrp;
        internal TradeMode TradeMode { get; }
        internal ExecutionAlgorithm ExecutionAlgorithm { get; }
        internal OrderType OrderType { get; }
        internal TimeInForce TimeInForce { get; }
        internal HandlingInstruction HandlingInstruction { get; }
        internal OrderReason OrderReason { get; }
        internal TradingDesk TradingDesk { get; }
        internal IEnumerable<ExecutionAlgoParam> ExecutionAlgoParams { get; }
        internal ExecutionChannel ExecutionChannel { get; }

        internal DateOnly? ContractMaturity => Instrument.Maturity;
        internal bool IsSingleAllocation()
            => OrderAllocations.Count() == 1;

        internal bool IsBlockOrder()
            => OrderAllocations.Count() > 1;
        internal IEnumerable<OrderAllocation> OrderAllocations { get; }
        public Order(
         BlockInfo blockInfo,
         IEnumerable<OrderAllocation> orderAllocations
        ) : this(
            blockInfo.RebalancingSessionId,
            blockInfo.Instrument,
            blockInfo.OrderSide,
            blockInfo.OrderType,
            blockInfo.TimeInForce,
            blockInfo.HandlingInstruction,
            blockInfo.ExecutionAlgorithm,
            blockInfo.ExecutionAlgoParams,
            blockInfo.ExecutionChannel,
            blockInfo.TradingDesk,
            blockInfo.TradeDate,
            blockInfo.Broker,
            blockInfo.TradeMode,
            blockInfo.OrderReason,
            orderAllocations
           )
        {
        }
        public Order(
         BaseOrder baseOrder,
         Broker broker,
         ExecutionProfile executionProfile,
         TradeMode tradeMode,
         OrderReason orderReason,
         TradingAccount tradingAccount
     ) : this(
         baseOrder.RebalancingSessionId,
         baseOrder.Instrument,
         baseOrder.OrderSide,
         executionProfile.OrderType,
         executionProfile.TimeInForce,
         executionProfile.HandlingInstruction,
         executionProfile.ExecutionAlgorithm,
         executionProfile.ExecutionAlgoParams,
         executionProfile.ExecutionChannel,
         executionProfile.TradingDesk,
         baseOrder.TradeDate,
         broker,
         tradeMode,
         orderReason,
         new List<OrderAllocation>() {
                 new OrderAllocation(
                     baseOrder.Portfolio,
                     tradingAccount,
                     baseOrder.Quantity,
                     baseOrder.PositionSide) }
        )
        {
        }
        public Order(
          BaseOrder baseOrder,
          Broker broker,
          OrderType orderType,
          TimeInForce timeInForce,
          HandlingInstruction handlingInstruction,
          ExecutionAlgorithm executionAlgorithm,
          IEnumerable<ExecutionAlgoParam> executionAlgoParams,
          ExecutionChannel executionChannel,
          TradingDesk tradingDesk,
          TradeMode tradeMode,
          OrderReason orderReason,
          TradingAccount tradingAccount
         ) : this(
             baseOrder.RebalancingSessionId,
             baseOrder.Instrument,
             baseOrder.OrderSide,
             orderType,
             timeInForce,
             handlingInstruction,
             executionAlgorithm,
             executionAlgoParams,
             executionChannel,
             tradingDesk,
             baseOrder.TradeDate,
             broker,
             tradeMode,
             orderReason,
             new List<OrderAllocation>() {
                 new OrderAllocation(
                     baseOrder.Portfolio,
                     tradingAccount,
                     baseOrder.Quantity,
                     baseOrder.PositionSide) }
            )
        {
        }

        public Order(int? rebalancingId,
            Instrument instrument,
            OrderSide orderSide,
            OrderType orderType,
            TimeInForce timeInForce,
            HandlingInstruction handlingInstruction,
            ExecutionAlgorithm executionAlgorithm,
            IEnumerable<ExecutionAlgoParam> executionAlgoParams,
            ExecutionChannel executionChannel,
            TradingDesk tradingDesk,
            DateOnly tradeDate,
            Broker broker,
            TradeMode tradeMode,
            OrderReason orderReason,
            IEnumerable<OrderAllocation> orderAllocations
           )
      : this(0,
            rebalancingId,
            instrument,
            orderSide,
            orderType,
            timeInForce,
            handlingInstruction,
            executionAlgorithm,
            executionAlgoParams,
            executionChannel,
            tradingDesk,
            tradeDate,
            broker,
            tradeMode,
            orderReason,
           orderAllocations)
        {

        }


        public Order(int id,
            int? rebalancingSessionId,
            Instrument instrument,
            OrderSide orderSide,
            OrderType orderType,
            TimeInForce timeInForce,
            HandlingInstruction handlingInstruction,
            ExecutionAlgorithm executionAlgorithm,
            IEnumerable<ExecutionAlgoParam> executionAlgoParams,
            ExecutionChannel executionChannel,
            TradingDesk tradingDesk,
            DateOnly tradeDate,
            Broker broker,
            TradeMode tradeMode,
            OrderReason orderReason,
            IEnumerable<OrderAllocation> orderAllocations)
        {
            OrderId = id;
            Instrument = instrument;
            TradeDate = tradeDate;
            RebalancingSessionId = rebalancingSessionId;
            Broker = broker;
            TradeMode = tradeMode;
            OrderSide = orderSide;
            Quantity = orderAllocations.Sum(x => x.Quantity);
            OrderAllocations = orderAllocations;
            ExecutionAlgorithm = executionAlgorithm;
            ExecutionAlgoParams = executionAlgoParams;
            OrderType = orderType;
            TimeInForce = timeInForce;
            HandlingInstruction = handlingInstruction;
            OrderReason = orderReason;
            ExecutionChannel = executionChannel;
            TradingDesk = tradingDesk;
        }

        internal BlockInfo GetBlockInfo()
            => new BlockInfo(RebalancingSessionId,
                Instrument,
                OrderSide,
                TradeDate,
                Broker,
                OrderType,
                TimeInForce,
                HandlingInstruction,
                ExecutionAlgorithm,
                ExecutionAlgoParams,
                ExecutionChannel,
                TradingDesk,
                TradeMode,
                OrderReason);
        public override string? ToString()
        {
            return $"{OrderId} {Instrument} {OrderSide} {Quantity} {OrderType} {TimeInForce} {ExecutionAlgorithm} {Broker} {TradingDesk} {TradeMode} {ExecutionChannel}";
        }
    }
}

