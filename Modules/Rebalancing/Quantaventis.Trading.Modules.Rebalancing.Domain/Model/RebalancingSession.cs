using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class RebalancingSession
    {
       
        internal int Id { get; }
        internal DateTime StartedOn { get; }
        internal DateOnly TradeDate { get; }
        internal RebalancingStatus.StatusReason StatusReason { get; }
        internal DateTime? EndedOn { get; }
        internal RebalancingStatus RebalancingStatus => StatusReason.Status;

        internal IEnumerable<PortfolioDrift> PortfolioDrifts { get; }

        internal RebalancingSession(
            int rebalancingSessionId,   
            IEnumerable<PortfolioDrift> portfolioDrifts,
            DateOnly tradeDate,
            DateTime startedOn, 
            RebalancingStatus.StatusReason statusReason)
        {
            Id = rebalancingSessionId;
            PortfolioDrifts = portfolioDrifts;  
            TradeDate= tradeDate;
            StartedOn = startedOn;
            StatusReason = statusReason;
            if (statusReason.Status == RebalancingStatus.Terminated())
                EndedOn = DateTime.UtcNow;

        }
        internal RebalancingSession(
         int rebalancingSessionId,
         IEnumerable<PortfolioDrift> portfolioDrifts,
         DateOnly tradeDate,
         DateTime startedOn,
         RebalancingStatus.StatusReason statusReason,
         DateTime? endedOn)
        {
            Id = rebalancingSessionId;
            PortfolioDrifts = portfolioDrifts;
            TradeDate = tradeDate;
            StartedOn = startedOn;
            StatusReason = statusReason;
            EndedOn = endedOn;

        }
        internal RebalancingSession TradesBooked()
        {
            return new RebalancingSession(Id, PortfolioDrifts, TradeDate, StartedOn, RebalancingStatus.StatusReason.TradesBooked());
        }
        internal RebalancingSession Validated() {
            return new RebalancingSession(Id, PortfolioDrifts, TradeDate, StartedOn, RebalancingStatus.StatusReason.Validated());
        }
        internal RebalancingSession Breached()
        {
            return new RebalancingSession(Id,PortfolioDrifts, TradeDate, StartedOn, RebalancingStatus.StatusReason.Breached());
        }
        internal RebalancingSession CancelLed()
        {
            return new RebalancingSession(Id, PortfolioDrifts, TradeDate, StartedOn, RebalancingStatus.StatusReason.Cancelled());
        }
        internal RebalancingSession CancellationStarted()
        {
            return new RebalancingSession(Id, PortfolioDrifts, TradeDate, StartedOn, RebalancingStatus.StatusReason.Cancelling());
        }
        internal static RebalancingSession Start(IEnumerable<PortfolioDrift> portfolioDrifts, DateOnly tradeDate) {
            return new RebalancingSession(
                0,
                portfolioDrifts,
                tradeDate,
                DateTime.UtcNow,          
                RebalancingStatus.StatusReason.Started());
        }

        internal  IEnumerable<Order> GetOrders()
            => PortfolioDrifts.SelectMany(x => x.GetOrders(this));

    }
}
