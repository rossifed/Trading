using Bloomberglp.Blpapi;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Messages.Handlers;
using Quantaventis.Trading.Modules.EMSX.Infrastructure.Options;

namespace Quantaventis.Trading.Modules.EMSX.Infrastructure.Services
{

    internal interface ISessionManager : ISessionMessageHandler, IServiceMessageHandler, IMiscMessageHandler
    {
        public event Action EmsxApiServiceOpen;
        public event Action HistoryServiceOpen;
        Task<bool> StartSessionAsync(IEmsxEventHandler emsxEventHander);
        void StopSession();
        Service? GetService(string serviceName);
        Session? GetSession();
        Session GetOpenSession();
        bool IsSessionOpen();
        bool IsServiceOpen(string serviceName);
    }
    internal class SessionManager : ISessionManager, IDisposable
    {
        private TaskCompletionSource<bool> _sessionOpenTcs { get; set; }
        private TaskCompletionSource<bool> _emsxServiceOpenTcs = new TaskCompletionSource<bool>();
        private TaskCompletionSource<bool> _historyServiceOpenTcs = new TaskCompletionSource<bool>();
        private TaskCompletionSource<bool> _connectionFailureTcs = new TaskCompletionSource<bool>();
        private ManualResetEventSlim SessionOpened = new ManualResetEventSlim(false);
        private ILogger<SessionManager> Logger { get; }
        public Session? Session { get; set; }
        private readonly object _sessionLock = new object();

        public event Action EmsxApiServiceOpen;
        public event Action HistoryServiceOpen;

        private string ServiceName { get; }
        private string HistoryServiceName { get; }
        internal string Host { get; }
        internal int Port { get; }
        internal int OpenSessionTimeout { get; } = 10000;//default 10 secs
        public SessionManager(
            EmsxApiOptions apiOptions,
            ILogger<SessionManager> logger)
        {
            Logger = logger;
            Host = apiOptions.Host;
            Port = apiOptions.Port;
            ServiceName = apiOptions.ServiceName;
            HistoryServiceName = apiOptions.HistoryServiceName;
            OpenSessionTimeout = apiOptions.OpenSessionTimeout;
            Logger.LogInformation($"Session Manager Initialized:{Host}:{Port}");

        }


        public async Task<bool> StartSessionAsync(IEmsxEventHandler emsxEventHandler)
        {
            try
            {
                
                    if (Session != null && IsSessionOpen())
                    {
                        Logger.LogInformation("Session is already started.");
                        return false;
                    }

                    SessionOptions sessionOptions = new SessionOptions
                    {
                        ServerHost = Host,
                        ServerPort = Port
                    };
                    Session = new Session(sessionOptions, emsxEventHandler.HandleEvent);
                _sessionOpenTcs = new TaskCompletionSource<bool>();
                Session.StartAsync();
          
                 await WaitForOpenConditionsAsync();
         
                return true;
              
            }
            catch (Exception ex)
            {
                Logger.LogError("Error starting the EMSX Session", ex);
                throw;
            }
            
        }


        private async Task WaitForOpenConditionsAsync()
        {
            try
            {
                // Await all tasks associated with the opening conditions.
                await Task.WhenAny( Task.WhenAll(_sessionOpenTcs.Task, _emsxServiceOpenTcs.Task, _historyServiceOpenTcs.Task), _connectionFailureTcs.Task); // Wait for the session to open
                      // Wait for the History service to open
               

                // If we reach this point, it means all conditions are met successfully.
           
                 // Indicate success
            }
            catch (Exception ex)
            {
                // If an exception occurs, it means one or more conditions failed.
                Logger.LogError("Error waiting for session and services to open", ex);
                 // Indicate failure
            }
        
    }
        public void StopSession()
        {
            lock (_sessionLock)
            {
                try
                {
                    if (IsSessionOpen())
                    {
                        Logger.LogInformation("Stopping EMSX Session...");
                        Session?.Stop();
                        SessionOpened.Reset();
                    }
                    else
                    {
                        Logger.LogInformation("Session is not open, cannot be stopped.");
                    }
                }
                catch (Exception ex)
                {
                    Logger.LogError("Error stopping the EMSX Session", ex);
                }
            }
        }
        public void Dispose()
        {
            lock (_sessionLock)
            {
                StopSession();
                SessionOpened.Dispose();
                Session = null;
            }
        }

        public void OnSessionStarted(Message msg, Session session)
        {
            Logger.LogInformation("Session started...");
            session.OpenServiceAsync(ServiceName);
         
                _sessionOpenTcs.SetResult(true);
           
            SessionOpened.Set();
        }

        public void OnSessionStartupFailure(Message msg, Session session)
        {
            Logger.LogError("Error: Session startup failed");
            SessionOpened.Dispose();
            _connectionFailureTcs.SetResult(true);
        }

        public void OnSessionConnectionUp(Message msg, Session session)
        {
 
            Logger.LogInformation("Session connection is up");
        }

        public void OnSessionConnectionDown(Message msg, Session session)
        {


            Logger.LogWarning("Session connection is down");
            SessionOpened.Dispose();
        }

        public void OnServiceOpened(Message msg, Session session)
        {
            var emsxApiService = session.GetService(ServiceName);
            var historyService = session.GetService(HistoryServiceName);
            if (emsxApiService != null && historyService == null)
            {
                Logger.LogInformation($"Service {emsxApiService.Name} opened..");
                _emsxServiceOpenTcs.SetResult(true);
                session.OpenService(HistoryServiceName);
            }
            if (historyService != null)
            {
                Logger.LogInformation($"Service {historyService.Name} opened..");
                 _historyServiceOpenTcs.SetResult(true);
            }
        }

        public void OnServiceOpenFailure(Message msg, Session session)
        {
            Logger.LogInformation($"Error: Service {msg.Service.Name} failed to open..");
        }

        public void OnMiscMessage(Message msg, Session session)
        {
            Logger.LogInformation($"Misc message received: {msg}");
        }

        public Session GetOpenSession()
        {
            lock (_sessionLock)
            {
                if (Session != null && IsSessionOpen())
                {
                    return Session;
                }
                throw new InvalidOperationException("Error: requesting a closed session");
            }
        }


        public Session? GetSession()
        {
            lock (_sessionLock)
            {
                return Session;
            }
        }



        public Service? GetService(string serviceName)
        {
            lock (_sessionLock)
            {
                return Session?.GetService(serviceName);
            }
        }




        public bool IsServiceOpen(string serviceName)
        {
            lock (_sessionLock)
            {
                return (Session != null && GetService(serviceName) != null);
            }
        }

        public bool IsSessionOpen()
        {
            lock (_sessionLock)
            {
                return Session != null && SessionOpened.IsSet;
            }
        }
    }
}
