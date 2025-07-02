using Quantaventis.Trading.Modules.Transmission.Domain.Model;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Exceptions
{
    internal class FileTransmissionException : Exception
    {


        internal TransmissionProfile TransmissionProfile { get; }
        public FileTransmissionException(TransmissionProfile transmissionProfile, Exception e): base($"Error transmitting files for transmission profile {transmissionProfile}",e) { 
        this.TransmissionProfile = transmissionProfile;

        }
    }
}
