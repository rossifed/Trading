using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Options;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Exceptions;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Services
{

    internal class FileArchiver : IFileArchiver
    {
 
        private Folder SuccessFolder { get; }
        private Folder ErrorFolder { get; }

        private string TimestampFormat { get; }
        public FileArchiver(FileArchivingOptions fileArchivingOptions)
        {
            SuccessFolder = new Folder(fileArchivingOptions.SuccessFolderName);
            ErrorFolder = new Folder(fileArchivingOptions.ErrorFolderName);
            TimestampFormat = fileArchivingOptions.TimestampFormat;
        }

        public void CreateDirectoryIfNotExists(Folder archiveFolder)
        {


            // Create the directory if it doesn't exist
            if (!Directory.Exists(archiveFolder.Path))
            {
                Directory.CreateDirectory(archiveFolder.Path);
            }

        }
      
        public TransmissionFile ArchiveToSuccessFolder(TransmissionFile file)
        {
            return ArchiveFile(file, SuccessFolder);
        }
        public TransmissionFile ArchiveToErrorFolder(TransmissionFile file) {
        
                return ArchiveFile(file, ErrorFolder);
           
        }
        private TransmissionFile ArchiveFile(TransmissionFile file, Folder archiveRelativeFolder)
        {


            try
            {

                if (string.IsNullOrEmpty(file.FullPath) || !File.Exists(file.FullPath))
                {
                    throw new ArgumentException("Provided file path is invalid or file doesn't exist.");
                }


              // TransmissionFile fileWithTimestamp = file.AddTimeStamp(DateTime.Now, TimestampFormat);


                Folder fullArchiveDirectory = file.Directory.Combine(archiveRelativeFolder);
                CreateDirectoryIfNotExists(fullArchiveDirectory);
                // Constructing the new file path
                TransmissionFile archiveFile = fullArchiveDirectory.CreateFile(file.FileName);



                // Moving the file to the new location
                File.Move(file.FullPath, archiveFile.FullPath);

                return archiveFile;
            }catch (Exception ex)
            {

                throw new FileArchivingException(file.FullPath, archiveRelativeFolder.Path,ex);
            }
        }


        public IEnumerable<TransmissionFile> ArchiveToSuccessFolder(IEnumerable<TransmissionFile> files)
        {
            List<TransmissionFile> archivedFiles = new List<TransmissionFile>();
            foreach (var file in files) {
                var archivedFile = ArchiveToSuccessFolder(file);
                archivedFiles.Add(archivedFile);
            }
            return archivedFiles;
        }

        public IEnumerable<TransmissionFile> ArchiveToErrorFolder(IEnumerable<TransmissionFile> files)
        {
            List<TransmissionFile> archivedFiles = new List<TransmissionFile>();
            foreach (var file in files)
            {
                var archivedFile = ArchiveToErrorFolder(file);
                archivedFiles.Add(archivedFile);
            }
            return archivedFiles;
        }
    }
}
