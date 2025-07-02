using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Orders.Domain.Model
{
    internal class ExecutionProfile
    {

        internal int Id { get; }
        internal ExecutionAlgorithm ExecutionAlgorithm { get; }
        internal OrderType OrderType { get; }
        internal TimeInForce TimeInForce { get; }
        internal HandlingInstruction HandlingInstruction { get; }

        internal TradingDesk TradingDesk { get; }
        internal IEnumerable<ExecutionAlgoParam> ExecutionAlgoParams{ get; }
        internal ExecutionChannel ExecutionChannel { get; }
        public ExecutionProfile(
             int id,
             OrderType orderType,
             TimeInForce timeInForce,
             HandlingInstruction handlingInstruction,
             ExecutionAlgorithm executionAlgorithm,
             IEnumerable<ExecutionAlgoParam> executionAlgoParams,
             ExecutionChannel executionChannel,
             TradingDesk tradingDesk
             )
        {
            Id = id;
            ExecutionAlgorithm = executionAlgorithm;
            OrderType = orderType;
            TimeInForce = timeInForce;
            HandlingInstruction = handlingInstruction;
            ExecutionAlgoParams = executionAlgoParams;
            ExecutionChannel = executionChannel;
            TradingDesk = tradingDesk;
        }

        public override bool Equals(object? obj)
        {
            return obj is ExecutionProfile profile &&
                   Id == profile.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
