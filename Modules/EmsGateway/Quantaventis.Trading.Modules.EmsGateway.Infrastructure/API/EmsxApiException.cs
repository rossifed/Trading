namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class EmsxApiException : Exception
    {
        public int ErrorCode { get; }

        public EmsxApiException(int errorCode, string message) : base($"{errorCode} {message}")
        {
            ErrorCode = errorCode;
        }

        public EmsxApiException(string message) : this(-1, message)
        {
        }

        public override string ToString()
        {
            return $"{ErrorCode}{Message}{base.ToString()}";
        }
    }
}
