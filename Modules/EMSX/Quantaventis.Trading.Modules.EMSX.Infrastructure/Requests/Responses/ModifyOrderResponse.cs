namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Requests.Responses
{
    internal class ModifyOrderResponse
    {
        public int EmsxSequence { get; }
        public string Message { get; }
        public ModifyOrderResponse(int emsxSequence, string message)
        {
            EmsxSequence = emsxSequence;
            Message = message;

        }

        public override string? ToString()
          => $"EmsxSequence:{EmsxSequence} {Message}";
    }
}
