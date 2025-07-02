using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Rebalancing.Domain.Model
{
    internal class RebalancingStatus
    {

        internal string Label { get; }
        private RebalancingStatus( string label)
        {
            this.Label = label;
        }



        internal static RebalancingStatus InProgress()
         => new RebalancingStatus("InProgress");



        internal static RebalancingStatus Terminated()
            => new RebalancingStatus("Terminated");

        public override bool Equals(object? obj)
        {
            return obj is RebalancingStatus status &&
                   Label == status.Label;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Label);
        }

        //internal static RebalancingStatus Aborted()
        //    => new RebalancingStatus(3, "Aborted");




        internal class StatusReason
        {
     
            internal string Label { get; }

            internal RebalancingStatus Status { get; }

            private StatusReason(string code, RebalancingStatus status)
            {
          
                this.Label = code;
                this.Status = status;
            }


            internal static StatusReason Started()
                 => new StatusReason("Started", RebalancingStatus.InProgress());
            internal static StatusReason Validated()
                 => new StatusReason("Validated", RebalancingStatus.InProgress());
            internal static StatusReason Breached()
                 => new StatusReason("Breached", RebalancingStatus.Terminated());
            internal static StatusReason Cancelled()
                => new StatusReason("Cancelled", RebalancingStatus.Terminated());
            internal static StatusReason Cancelling()
               => new StatusReason("Cancelling", RebalancingStatus.InProgress());
            internal static StatusReason TradesBooked()
                => new StatusReason("TradesBooked", RebalancingStatus.Terminated());

            internal static StatusReason Error()
                => new StatusReason("Error", RebalancingStatus.Terminated());

            internal static StatusReason FromLabel(string code)
            {
                IEnumerable<StatusReason> statusReasons = new List<StatusReason>() {
            Started(),Validated(), Breached(),
                Cancelled(), Error(), Cancelling()
            };
                return statusReasons
                      .Where(x => x.Label.ToUpper().Equals(code.Trim().ToUpper()))
                      .Single();
            }

            public override bool Equals(object? obj)
             => obj is StatusReason reason &&
                      Label == reason.Label;


            public override int GetHashCode()
             => HashCode.Combine(Label);
        }
    }

}
