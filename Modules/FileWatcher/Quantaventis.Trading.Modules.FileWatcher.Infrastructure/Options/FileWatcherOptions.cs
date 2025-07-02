using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Module.FileWatcher.Infrastructure.Configuration
{
    public class FileWatcherOptions
    {
        public List<FileWatcherSettings> FileWatchers { get; set; }
        public class FileWatcherSettings
        {
            public string Topic { get; set; }
            public string FolderPath { get; set; }
            public string FilePattern { get; set; }
            public bool WatchCreate { get; set; }
            public bool WatchUpdate { get; set; }
            public bool WatchDelete { get; set; }
            public Dictionary<string, string> Metadata { get; set; }
        }
    }
}
