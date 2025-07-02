namespace Quantaventis.Trading.Modules.EMSX.Api.Dto
{
    public class DeleteOrderRequestDto
    {

        public IEnumerable<int> EmsxSequences { get; set; } = new List<int>();

    }
}
