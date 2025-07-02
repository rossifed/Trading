namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class FileTransmission
    {


        internal string TransmissionType { get; }

        internal DateTime TransmittedOn { get; }
        internal string ContentType { get; }
        internal bool IsFtpTransmitted { get; }

        internal bool IsEmailTransmitted { get; }
        internal int TransmittedFilesCount => TransmittedFiles.Count();
        internal string Counterparty { get; }
        internal IEnumerable<TransmissionFile> TransmittedFiles { get; }
        internal FileTransmission(string transmissionType,
             string counterparty,
             string contentType,
            DateTime transmittedOn,
            bool isFtpTransmitted,
            bool isEmailTransmitted,
            IEnumerable<TransmissionFile> transmittedFiles)
        {
            TransmissionType = transmissionType;
            TransmittedOn = transmittedOn;
            ContentType = contentType;
            IsFtpTransmitted = isFtpTransmitted;
            IsEmailTransmitted = isEmailTransmitted;
            Counterparty = counterparty;
            TransmittedFiles = transmittedFiles;
        }


    }
}
