using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal struct BlockInfo
    {
        internal Instrument Instrument { get; }
        internal Broker Broker { get; }
        internal TradeMode TradeMode { get; }
        internal int? RebalancingSessionId { get; }
        internal OrderType OrderType { get; }
        internal TimeInForce TimeInForce { get; }
        internal HandlingInstruction HandlingInstruction { get; }
        internal ExecutionAlgorithm ExecutionAlgorithm { get; }
        internal IEnumerable<ExecutionAlgoParam> ExecutionAlgoParams { get; }
        internal ExecutionChannel ExecutionChannel { get; }
        internal TradingDesk TradingDesk { get; }
        internal OrderReason OrderReason { get; }
        internal bool IsCfd => TradeMode.TradeAsCFD;
        internal OrderSide OrderSide { get; }
        internal DateOnly TradeDate { get; }
        public BlockInfo(
            int? rebalancingSessionId, 
            Instrument instrument, 
            OrderSide orderSide,
            DateOnly tradeDate,
            Broker broker,
            OrderType orderType,
            TimeInForce timeInForce,
            HandlingInstruction handlingInstruction,
            ExecutionAlgorithm executionAlgorithm,
            IEnumerable<ExecutionAlgoParam> executionAlgoParams,
            ExecutionChannel executionChannel,
            TradingDesk tradingDesk,
            TradeMode tradeMode,
            OrderReason orderReason)
        {
            this.Instrument = instrument;
            this.Broker = broker;
            this.TradeDate= tradeDate;
            this.RebalancingSessionId = rebalancingSessionId;
            this.TradeMode = tradeMode;
            this.OrderSide = orderSide;
            ExecutionAlgorithm = executionAlgorithm;
            OrderType = orderType;
            TimeInForce = timeInForce;
            HandlingInstruction = handlingInstruction;
            ExecutionAlgoParams = executionAlgoParams;
            ExecutionChannel = executionChannel;
            TradingDesk = tradingDesk;
            OrderReason = orderReason;
        }

        public override bool Equals(object? obj)
        {
            return obj is BlockInfo info &&
                   EqualityComparer<Instrument>.Default.Equals(Instrument, info.Instrument) &&
                   EqualityComparer<Broker>.Default.Equals(Broker, info.Broker) &&
     
                   EqualityComparer<TradeMode>.Default.Equals(TradeMode, info.TradeMode) &&
                   RebalancingSessionId == info.RebalancingSessionId &&
                   EqualityComparer<OrderType>.Default.Equals(OrderType, info.OrderType) &&
                   EqualityComparer<TimeInForce>.Default.Equals(TimeInForce, info.TimeInForce) &&
                   EqualityComparer<HandlingInstruction>.Default.Equals(HandlingInstruction, info.HandlingInstruction) &&
                   EqualityComparer<ExecutionAlgorithm>.Default.Equals(ExecutionAlgorithm, info.ExecutionAlgorithm) &&
                   EqualityComparer<IEnumerable<ExecutionAlgoParam>>.Default.Equals(ExecutionAlgoParams, info.ExecutionAlgoParams) &&
                   EqualityComparer<ExecutionChannel>.Default.Equals(ExecutionChannel, info.ExecutionChannel) &&
                   EqualityComparer<TradingDesk>.Default.Equals(TradingDesk, info.TradingDesk) &&
                   EqualityComparer<OrderSide>.Default.Equals(OrderSide, info.OrderSide) &&
                   EqualityComparer<OrderReason>.Default.Equals(OrderReason, info.OrderReason) &&
                   TradeDate.Equals(info.TradeDate);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Instrument);
            hash.Add(Broker);
       
            hash.Add(TradeMode);
            hash.Add(RebalancingSessionId);
            hash.Add(OrderType);
            hash.Add(TimeInForce);
            hash.Add(HandlingInstruction);
            hash.Add(ExecutionAlgorithm);
            hash.Add(ExecutionAlgoParams);
            hash.Add(ExecutionChannel);
            hash.Add(TradingDesk);
            hash.Add(OrderSide);
            hash.Add(TradeDate);
            hash.Add(OrderReason);
            return hash.ToHashCode();
        }
    }
}
