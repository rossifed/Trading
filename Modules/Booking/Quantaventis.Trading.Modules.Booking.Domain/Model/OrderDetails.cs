namespace Quantaventis.Trading.Modules.Booking.Domain.Model
{
    internal class OrderDetails
    {
        internal int? EmsxOrderId { get; }
        internal int? OrderReferenceId { get; }
        internal int? OrderQuantity { get; }
        internal string? OrderType { get; }
        internal string? StrategyType { get; }
        internal string? TimeInForce { get; }
        internal string? OrderExecutionInstruction { get; }
        internal string? OrderHandlingInstruction { get; }
        internal string? OrderInstruction { get; }
        internal decimal? LimitPrice { get; }
        internal decimal? StopPrice { get; }
        internal int? OriginatingTraderUUId { get; }
        internal string? TraderName { get; }
        internal int? TraderUuid { get; set; }
        internal decimal? UserCommissionAmount { get; set; }
        internal decimal? UserCommissionRate { get; set; }
        internal decimal? UserFees { get; set; }
        internal decimal? UserNetMoney { get; set; }
        internal static OrderDetails Empty() => new OrderDetails();
        private OrderDetails() { }
        internal OrderDetails AdjustQuantitySign(TradeSide tradeSide)
        {
            return new OrderDetails(EmsxOrderId,
                OrderReferenceId,
                OrderQuantity != null ? new Quantity(OrderQuantity.Value).AdjustSign(tradeSide) : OrderQuantity,
                OrderType,
                StrategyType,
                TimeInForce,
                OrderExecutionInstruction,
                OrderHandlingInstruction,
                OrderInstruction,
                LimitPrice,
                StopPrice,
                OriginatingTraderUUId,
                TraderName,
                TraderUuid,
                UserCommissionAmount,
                UserCommissionRate,
                UserFees,
                UserNetMoney);
        }
        public OrderDetails(int? emsxOrderId,
            int? orderReferenceId,
            int? orderQuantity,
            string? orderType,
            string? strategyType,
            string? timeInForce,
            string? orderExecutionInstruction,
            string? orderHandlingInstruction,
            string? orderInstruction,
            decimal? limitPrice,
            decimal? stopPrice,
            int? originatingTraderUUId,
            string? traderName,
            int? traderUuid,
            decimal? userCommissionAmount,
            decimal? userCommissionRate,
            decimal? userFees,
            decimal? userNetMoney)
        {
            EmsxOrderId = emsxOrderId;
            OrderReferenceId = orderReferenceId;
            OrderQuantity = orderQuantity;
            OrderType = orderType;
            StrategyType = strategyType;
            TimeInForce = timeInForce;
            OrderExecutionInstruction = orderExecutionInstruction;
            OrderHandlingInstruction = orderHandlingInstruction;
            OrderInstruction = orderInstruction;
            LimitPrice = limitPrice;
            StopPrice = stopPrice;
            OriginatingTraderUUId = originatingTraderUUId;
            TraderName = traderName;
            TraderUuid = traderUuid;
            this.UserCommissionAmount = userCommissionAmount;
            this.UserCommissionRate = userCommissionRate;
            this.UserFees = userFees;
            this.UserNetMoney = userNetMoney;
        }
    }
}
