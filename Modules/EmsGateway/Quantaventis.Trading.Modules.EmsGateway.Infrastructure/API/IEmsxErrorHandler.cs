namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public interface IEmsxErrorHandler
    {

        void OnError(int errorCode, string errorMessage);
        void OnError(string errorMessage);
    }
}
