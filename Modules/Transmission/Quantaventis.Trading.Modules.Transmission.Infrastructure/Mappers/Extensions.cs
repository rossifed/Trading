using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;
using DomainModel = Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Mappers
{
    internal static class Extensions
    {
        internal static IEnumerable<DomainModel.TransmissionProfile> Map(this IEnumerable<Entities.TransmissionProfile> entities)
        {

            return entities.Select(x => x.Map()).ToList();
        }
        internal static DomainModel.TransmissionProfile Map(this Entities.TransmissionProfile entity)
        {

            return new DomainModel.TransmissionProfile(entity.TransmissionProfileId,
                entity.Mnemonic,
                entity.CounterParty.Map(),
                entity.FileContentType.Map(),
                entity.EncryptionProfile?.Map(),
                entity.FtpConfiguration?.Map(),
                entity.EmailConfiguration?.Map(),
                entity.TransmissionScheduleType.Map(),
                entity.FileGenerationProfiles.Map()
                );
        }
        internal static DomainModel.TransmissionScheduleType Map(this Entities.TransmissionScheduleType entity)
        {
            var mnemonic = entity.Mnemonic;
            TransmissionScheduleType type;
            if (Enum.TryParse<TransmissionScheduleType>(mnemonic, true, out type))
            {
                return type;
            }
            else
            {
                throw new Exception($"Not recognized TransmissionScheduleType {mnemonic}");
            }
            
        }

        internal static IEnumerable<DomainModel.FileGenerationProfile> Map(this IEnumerable<Entities.FileGenerationProfile> entities)
        {

            return entities.Select(x => x.Map()).ToList();
        }
        internal static DomainModel.FileGenerationProfile Map(this Entities.FileGenerationProfile entity)
        {
            var fileContentGenerationInfo = new FileContentGenerationInfo(entity.PortfolioId, entity.FunctionName, entity.IncludeHeader, entity.Separator);
            var fileNameGenerationInfo = new FileNameGenerationInfo(new DomainModel.FileNameTemplate(entity.FileName), entity.DateParamFormat);
            return new DomainModel.FileGenerationProfile(
                   entity.FileGenerationProfileId,
                   fileContentGenerationInfo,
                   fileNameGenerationInfo,
                   new DomainModel.Folder(entity.OutputFolder)
            );
        }
        internal static DomainModel.Counterparty Map(this Entities.Counterparty entity)
        {
            return new DomainModel.Counterparty(entity.Name);
        }
        internal static DomainModel.ContentType Map(this Entities.FileContentType entity)
        {
            return new DomainModel.ContentType(entity.Mnemonic);
        }
        internal static DomainModel.FtpConfiguration Map(this Entities.FtpConfiguration entity)
        {
            return new DomainModel.FtpConfiguration(
          entity.Host,
          entity.Port,
          entity.Username,
          entity.Password,
          entity.IsSftp,
          new DomainModel.Folder(entity.RemoteFolder));
        }

        internal static DomainModel.EmailConfiguration Map(this Entities.EmailConfiguration entity)
        {
            return new DomainModel.EmailConfiguration(
                entity.Recipients,
                entity.EmailSubject,
                entity.MessageBody,
                entity.AttachFile);
        }


        internal static DomainModel.EncryptionProfile Map(this Entities.EncryptionProfile entity)
        {
            return new DomainModel.EncryptionProfile(
                entity.EncryptionProfileId,
                entity.PublicKeyRecipient,
                entity.PrivateKeyRecipient,
                entity.Passphrase,
                entity.Sign,
                entity.ExcryptedFileExtension);
        }

        internal static Entities.TransmittedFile Map(this DomainModel.TransmissionFile file)
        {
            return new Entities.TransmittedFile()
            {
                FileName = file.FileName.Value,
                 FilePath = file.FullPath,
              RowsCount = file.RowsCount
                 
            };
       
        }

        internal static Entities.FileTransmission Map(this DomainModel.FileTransmission domain)
        {
            var entity = new Entities.FileTransmission() {
                Counterparty = domain.Counterparty,
                IsEmailTransmitted = domain.IsEmailTransmitted,
                IsFtpTransmitted = domain.IsFtpTransmitted,
                TransmissionType = domain.TransmissionType,
                TransmittedOn = domain.TransmittedOn,
               ContentType = domain.ContentType
            };

            foreach (var item in domain.TransmittedFiles)
            {
                entity.TransmittedFiles.Add(item.Map());
            }
            return entity;
        }
    }
}
