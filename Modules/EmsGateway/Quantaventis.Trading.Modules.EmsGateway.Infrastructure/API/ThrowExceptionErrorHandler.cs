namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class ThrowExceptionErrorHandler : IEmsxErrorHandler
    {
        public void OnError(int errorCode, string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(errorMessage);
            throw new EmsxApiException(errorCode, errorMessage);
        }

        public void OnError(string errorMessage)
        {
            System.Diagnostics.Debug.WriteLine(errorMessage);
            throw new EmsxApiException(errorMessage);
        }
    }
}
