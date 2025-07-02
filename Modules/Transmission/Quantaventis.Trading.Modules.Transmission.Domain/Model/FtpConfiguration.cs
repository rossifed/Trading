using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FtpConfiguration
    {

        public string Host { get;  } 

        public int Port { get;  }

        public string Username { get;  } 

        public string Password { get; } 

        public bool IsSftp { get; }

        public Folder RemoteFolder { get;  }

        public FtpConfiguration(
            string host, 
            int port, 
            string username,
            string password, 
            bool isSftp, 
            Folder remoteFolder)
        {
            Host = host;
            Port = port;
            Username = username;
            Password = password;
            IsSftp = isSftp;
            RemoteFolder = remoteFolder;
        }

        public override bool Equals(object? obj)
        {
            return obj is FtpConfiguration configuration &&
                   Host == configuration.Host &&
                   Port == configuration.Port &&
                   Username == configuration.Username &&
                   Password == configuration.Password &&
                   IsSftp == configuration.IsSftp &&
                   EqualityComparer<Folder>.Default.Equals(RemoteFolder, configuration.RemoteFolder);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Host, Port, Username, Password, IsSftp, RemoteFolder);
        }

        public override string? ToString()
        {
            return $"{Username}@{Host}";
        }
    }
}
