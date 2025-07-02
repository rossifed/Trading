namespace Quantaventis.Trading.Modules.Orders.Api.Dto
{
    internal class PositionRolloverDto
    {
        public byte PortfolioId { get; set; }
        public int ExpiringContractId { get; set; }

        public int NextContractId { get; set; }
        public int ExpiringQuantity { get; set; }

        public int NextQuantity { get; set; }

        public DateOnly RollDate { get; set; }
    }
}
