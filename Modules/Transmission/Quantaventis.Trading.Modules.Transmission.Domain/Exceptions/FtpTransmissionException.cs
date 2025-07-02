using Quantaventis.Trading.Modules.Transmission.Domain.Model;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Exceptions
{
    internal class FtpTransmissionException : Exception
    {
        internal FtpConfiguration FtpConfiguration {get;}

  
        public FtpTransmissionException(FtpConfiguration ftpConfiguration,  Exception e): base($"Error uploading file  into FTP repo {ftpConfiguration}",e) { 

        this.FtpConfiguration = ftpConfiguration;
        }
    }
}
