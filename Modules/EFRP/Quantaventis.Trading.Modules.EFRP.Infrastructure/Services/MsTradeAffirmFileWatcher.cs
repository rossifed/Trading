using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.EFRP.Infrastructure.Services
{
    internal class MsAffirmFileWatcher : IHostedService, IDisposable
    {

        private FileSystemWatcher FileWatcher { get; set; }
        private  IMsTradeAffirmFileReader MsTradeAffirmFileReader;
        private readonly string _folderPath;

        private ILogger<MsAffirmFileWatcher> Logger { get; }

        public MsAffirmFileWatcher(IMsTradeAffirmFileReader msTradeAffirmFileReader, string folderPath, ILogger<MsAffirmFileWatcher> logger)
        {
         
            MsTradeAffirmFileReader = msTradeAffirmFileReader;
            _folderPath = folderPath;
            Logger = logger;
        }

        public  Task StartAsync(CancellationToken cancellationToken)
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
            }

            FileWatcher = new FileSystemWatcher(_folderPath);
            FileWatcher.Created += async (sender, e) => await OnCreatedAsync(sender, e); ;
            FileWatcher.EnableRaisingEvents = true;

            Logger.LogInformation("File watcher service started.");

            return Task.CompletedTask;
        }

        private async Task OnCreatedAsync(object sender, FileSystemEventArgs e)
        {
            Logger.LogInformation($"New file detected: {e.FullPath}");
           await  MsTradeAffirmFileReader.ReadTradeAffirmFutureItemsAsync(e.FullPath);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Logger.LogInformation("File watcher service stopped.");
            FileWatcher.EnableRaisingEvents = false;
            FileWatcher.Dispose();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            FileWatcher?.Dispose();
        }
    }
}
