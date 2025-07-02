using FluentFTP;
using Microsoft.Extensions.Logging;
using Quantaventis.Trading.Modules.Transmission.Domain.Exceptions;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
using Renci.SshNet;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Services
{

    internal class FtpUploader : IFtpUploader
    {
        private ILogger<FtpUploader> Logger { get; }

        public FtpUploader(ILogger<FtpUploader> logger)
        {
            Logger = logger;
        }
        public void UploadFile(TransmissionFile file, FtpConfiguration ftpConfiguration)
        {

            UploadFiles(new List<TransmissionFile>() { file }, ftpConfiguration);
        }
        public void UploadFiles(IEnumerable<TransmissionFile> files, FtpConfiguration ftpConfiguration)
        {

            if (ftpConfiguration.IsSftp)
                UploadFilesSftp(files, ftpConfiguration);
            else
                UploadFilesFtp(files, ftpConfiguration);
        }


        private void UploadFilesFtp(IEnumerable<TransmissionFile> files, FtpConfiguration ftpConfiguration)
        {
            string host = ftpConfiguration.Host;
            int port = ftpConfiguration.Port; // default port for SFTP
            string username = ftpConfiguration.Username;
            string password = ftpConfiguration.Password;
            Folder remoteFolder = ftpConfiguration.RemoteFolder;
            using (var ftpClient = new FtpClient(host, username, password, port))
            {
                try
                {
                    Logger.LogInformation($"Connecting to FTP repo {username}@{host}...");
                    ftpClient.Connect();

                    foreach (var file in files)
                    {

                        Logger.LogInformation($"Uploading File {file} in the remote folder {remoteFolder}");
                        ftpClient.UploadFile(file.FullPath, remoteFolder.CreateFile(file.FileName).FullPath);


                    }
                }
                catch (Exception e)
                {
                    Logger.LogError($"Error while uploading file to {username}@{host} via FTP...", e);
                    throw new FtpTransmissionException(ftpConfiguration, e);
                }
                finally
                {
                    ftpClient.Disconnect();
                }
            }
        }



        private void UploadFileSftp(SftpClient sftpClient, TransmissionFile file, Folder remoteFolder)
        {
            using (var fileStream = new FileStream(file.FullPath, FileMode.Open))
            {

                Logger.LogInformation($"Uploading File {file}  in the remote folder {remoteFolder}");
                sftpClient.UploadFile(fileStream, remoteFolder.CreateFile(file.FileName).FullPath);

            }
        }


        public void UploadFilesSftp(IEnumerable<TransmissionFile> files, FtpConfiguration ftpConfiguration)
        {
            string host = ftpConfiguration.Host;
            int port = ftpConfiguration.Port; // default port for SFTP
            string username = ftpConfiguration.Username;
            string password = ftpConfiguration.Password;
            Folder remoteDirectory = ftpConfiguration.RemoteFolder;
            using (var sftpClient = new SftpClient(host, port, username, password))
            {
                try
                {
                    Logger.LogInformation($"Connecting to  SFTP repo {username}@{host}...");
                    sftpClient.Connect();


                    foreach (var file in files)
                    {

                        UploadFileSftp(sftpClient, file, remoteDirectory);

                    }
                }
                catch (Exception e)
                {
                    Logger.LogError($"Error while uploading file to {username}@{host} via SFTP...", e);
                    throw new FtpTransmissionException(ftpConfiguration, e);

                }
                finally
                {
                    sftpClient.Disconnect();
                }

            }
        }
    }
}
