using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class TransmissionProfile
    {
        internal int TransmissionProfileId { get; }

        internal string Mnemonic { get; }

        internal Counterparty CounterParty { get; }
        internal EncryptionProfile? EncryptionProfile { get; }
        internal FtpConfiguration? FtpConfiguration { get; }
        internal EmailConfiguration? EmailConfiguration { get; }

        internal ContentType ContentType { get; }
        internal bool IsEODTranmsission => TransmissionScheduleType == TransmissionScheduleType.EOD;


        internal bool IsAwaitingEndOfDAy(TimeOnly eodTime) => IsEODTranmsission && eodTime > TimeOnly.FromDateTime(DateTime.UtcNow);

        public override bool Equals(object? obj)
        {
            return obj is TransmissionProfile profile &&
                   TransmissionProfileId == profile.TransmissionProfileId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TransmissionProfileId);
        }
        internal bool IsEmailTransmissionActive => EmailConfiguration != null;
        internal bool IsFtpTransmissionActive => FtpConfiguration != null;
        internal TransmissionScheduleType TransmissionScheduleType { get; }

        public  IEnumerable<FileGenerationProfile> FileGenerationProfiles { get; }

        public TransmissionProfile(int transmissionProfileId, 
            string mnemonic, 
            Counterparty counterParty,
            ContentType contentType,
            EncryptionProfile? encryptionProfile, 
            FtpConfiguration? ftpConfiguration, 
            EmailConfiguration? emailConfiguration, 
            TransmissionScheduleType transmissionScheduleType,
            IEnumerable<FileGenerationProfile> fileGenerationProfiles)
        {
            TransmissionProfileId = transmissionProfileId;
            Mnemonic = mnemonic;
            CounterParty = counterParty;
            ContentType = contentType;
            EncryptionProfile = encryptionProfile;
            FtpConfiguration = ftpConfiguration;
            EmailConfiguration = emailConfiguration;
            TransmissionScheduleType = transmissionScheduleType;
            FileGenerationProfiles = fileGenerationProfiles;
        }

        public override string? ToString()
        {
            return Mnemonic;
        }
    }


}
