namespace Quantaventis.Trading.Modules.EMSX.Api.Dto
{
    public class AssignTraderRequestDto
    {

        public IEnumerable<int> Sequences { get; set; }
        public int AssigneeTraderUuid { get; set; }

    }
}
