namespace Quantaventis.Trading.Modules.EmsGateway.Infrastructure.API
{
    public class EmsxClient
    {

        private EmsxClient()
        {
        }



        public static EmsxSession Connect(EmsxSessionOptions emsxSessionOptions)
        {
            EmsxSession session = new EmsxSession(emsxSessionOptions);
            return StartSession(session);
        }


     
        public static EmsxSession Connect(EmsxSessionOptions emsxSessionOptions, IEmsxEventHandler eventHandler)
        {
            EmsxSession session = new EmsxSession(emsxSessionOptions, eventHandler);
            return StartSession(session);
        }
        private  static  EmsxSession StartSession(EmsxSession session)
        {
             session.StartAsync();
            while (!session.IsOpen && !session.Aborted) {
           
            };
            return session;
        }
 

    }
}
