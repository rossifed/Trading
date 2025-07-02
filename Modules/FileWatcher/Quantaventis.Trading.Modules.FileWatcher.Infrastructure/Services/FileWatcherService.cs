using Microsoft.Extensions.FileSystemGlobbing;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Module.FileWatcher.Infrastructure.Configuration;
using Quantaventis.Trading.Module.FileWatcher.Infrastructure.Events.Out;
using Quantaventis.Trading.Shared.Abstractions.Events;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Module.FileWatcher.Infrastructure.Services
{
    public class FileWatcherService : IHostedService, IDisposable
    {
        private FileWatcherOptions FileWatcherOptions { get; }
        private List<FileSystemWatcher> Watchers { get; }
        private IEventDispatcher EventDispatcher { get; }
        private ILogger<FileWatcherService> Logger { get; }

        public FileWatcherService(
            FileWatcherOptions fileWatcherOptions,
            IEventDispatcher eventDispatcher,
            ILogger<FileWatcherService> logger)
        {
            FileWatcherOptions = fileWatcherOptions;
            Watchers = new List<FileSystemWatcher>();
            EventDispatcher = eventDispatcher;
            Logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        { 
            foreach (var watcherSettings in FileWatcherOptions.FileWatchers)
            {
                try
                {
                    if (!Directory.Exists(watcherSettings.FolderPath))
                    {
                        Directory.CreateDirectory(watcherSettings.FolderPath);
                    }

                    var watcher = new FileSystemWatcher(watcherSettings.FolderPath)
                    {
                        IncludeSubdirectories = false,
                        EnableRaisingEvents = true
                    };

                    watcher.Error += async (sender, e) => await OnErrorAsync(sender, e); // Handle errors

                    if (watcherSettings.WatchCreate)
                    {
                        watcher.Created += async (sender, e) => await OnChanged(e, "Create", watcherSettings);
                    }
                    if (watcherSettings.WatchUpdate)
                    {
                        watcher.Changed += async (sender, e) => await OnChanged(e, "Update", watcherSettings);
                    }
                    if (watcherSettings.WatchDelete)
                    {
                        watcher.Deleted += async (sender, e) => await OnChanged(e, "Delete", watcherSettings);
                    }

                    Watchers.Add(watcher);

                    Logger.LogInformation($"Started watching folder: {watcherSettings.FolderPath} with pattern: {watcherSettings.FilePattern}");
                } catch (Exception ex)
                {
                    Logger.LogError(ex,$"File Watcher initialization error: {watcherSettings.FolderPath} with pattern: {watcherSettings.FilePattern}");

                }
            }

            return Task.CompletedTask;
        }

        private async Task OnErrorAsync(object sender, ErrorEventArgs e)
        {
            Logger.LogError(e.GetException(), "FileSystemWatcher encountered an error");
            RestartWatcher((FileSystemWatcher) sender);
            await Task.CompletedTask;
        }

        private void RestartWatcher(FileSystemWatcher watcher)
        {
            if (watcher != null)
            {
                try
                {
                    watcher.EnableRaisingEvents = false;
                    watcher.EnableRaisingEvents = true;
                    Logger.LogInformation("FileSystemWatcher restarted successfully.");
                }
                catch (Exception ex)
                {
                    Logger.LogError(ex, "Error restarting FileSystemWatcher.");
                }
            }
        }

        private async Task OnChanged(FileSystemEventArgs e, string eventType, FileWatcherOptions.FileWatcherSettings settings)
        {
            try
            {
                // Using FileSystemGlobbing for pattern matching
                var matcher = new Matcher();
                matcher.AddInclude(settings.FilePattern);

                var directoryInfo = new DirectoryInfo(settings.FolderPath);
                var result = matcher.Execute(new DirectoryInfoWrapper(directoryInfo));
                var matchedFile = result.Files
                    .Select(fileMatch => Path.GetFullPath(Path.Combine(directoryInfo.FullName, fileMatch.Path)))
                    .FirstOrDefault(fullPath => string.Equals(fullPath, e.FullPath, StringComparison.OrdinalIgnoreCase));

                if (!string.IsNullOrEmpty(matchedFile))
                {
                    Logger.LogInformation($"File {eventType} detected: {e.FullPath} in {settings.FolderPath}");
                    var fileWatcherEvent = new FileWatcherEvent(eventType, settings.Topic, settings.FolderPath, e.FullPath, settings.Metadata);
                    await EventDispatcher.PublishAsync(fileWatcherEvent);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error processing file {eventType} event for {e.FullPath}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            foreach (var watcher in Watchers)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
            }

            Watchers.Clear();
            Logger.LogInformation("File watcher service stopped.");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            foreach (var watcher in Watchers)
            {
                watcher?.Dispose();
            }
        }
    }
}
