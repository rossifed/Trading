using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    internal  class OrderStatus
    {
        internal string Label { get; }
        private OrderStatus(string label)
        {
            Label = label;
        }


        public static implicit operator string(OrderStatus orderSide) => orderSide.Label;
        public static implicit operator OrderStatus(string label) => new(label);
        public bool IsExecuted => this == PARTFILLED || this == FILLED;
        public bool IsCompleted =>  this == PARTFILLED || this == FILLED || this == EXPIRED;
        public bool IsActive => this == NEW || IsProcessing;
        public bool IsProcessing => this == SENT || this == WORKING;

        public bool IsAborted => this == CANCEL || this == ASSIGN;

        internal static readonly OrderStatus NEW = new OrderStatus("NEW");
        internal static readonly OrderStatus ASSIGN = new OrderStatus("ASSIGN");
        internal static readonly OrderStatus CANCEL = new OrderStatus("CANCEL");

        internal static readonly OrderStatus WORKING = new OrderStatus("WORKING");
        internal static readonly OrderStatus SENT = new OrderStatus("SENT");
        internal static readonly OrderStatus PARTFILLED = new OrderStatus("PARTFILLED");
        internal static readonly OrderStatus FILLED = new OrderStatus("FILLED");
        internal static readonly OrderStatus EXPIRED = new OrderStatus("EXPIRED");

        public override string? ToString()
        {
            return Label;
        }

        public override bool Equals(object? obj)
        {
            return obj is OrderStatus status &&
                   Label == status.Label;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Label);
        }
    }
}
