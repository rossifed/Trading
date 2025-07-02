namespace Quantaventis.Trading.Modules.EMSX.Api.Dto
{
    public class CreateBasketRequestDto
    {
        public string BasketName { get; set; }

        public IEnumerable<int> Sequences { get; set; }

    }
}
