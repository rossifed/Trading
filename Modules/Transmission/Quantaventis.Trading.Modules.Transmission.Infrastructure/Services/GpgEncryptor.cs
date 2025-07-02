
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
using Quantaventis.Trading.Modules.Transmission.Domain.Exceptions;
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Options;
using System.Diagnostics;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Services
{

    internal class GpgEncryptor : IFileEncryptor
    {
        private GpgEncryptionOptions GpgEncryptionOptions { get; }

        public GpgEncryptor(GpgEncryptionOptions gpgEncryptionOptions)
        {
            GpgEncryptionOptions = gpgEncryptionOptions;
        }


        public async Task<TransmissionFile> EncryptFileAsync(TransmissionFile file, EncryptionProfile encryptionProfile)
        {

           TransmissionFile outputFile = file.AddExtension(encryptionProfile.ExcryptedFileExtension);

            var psi = new ProcessStartInfo
            {
                FileName = GpgEncryptionOptions.GpgPath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = BuildGpgArguments(
                file.FullPath,
                outputFile.FullPath,
                encryptionProfile)
            };

            using (var process = new Process { StartInfo = psi })
            {
                process.Start();
                await process.WaitForExitAsync();
                if (process.ExitCode != 0)
                {
                    var errorMessage = await process.StandardError.ReadToEndAsync();
                    throw new IOException($"GPG failed with exit code {process.ExitCode}: {errorMessage}");
                }
            }
            System.IO.File.Delete(file.FullPath);
            return outputFile;
        }
        private string BuildGpgArguments(string inputFilePath, string outputFilePath, EncryptionProfile encryptionProfile)
        {
            try
            {
                var privateKey = encryptionProfile.PrivateKeyRecipient;
                string[] publicKey = encryptionProfile.PublicKeyRecipient.Split(';');
                var passphrase = GpgEncryptionOptions.Passphrase;
                var homedir = GpgEncryptionOptions.Homedir;
                return GpgCommandBuilder.BuildGpgArguments(homedir,
                    privateKey,
                    publicKey,
                    passphrase,
                    inputFilePath,
                    outputFilePath);
            }
            catch (Exception ex)
            {
                throw new FileEncryptionException(inputFilePath, ex);
            }
        }

        public async Task<IEnumerable<TransmissionFile>> EncryptFilesAsync(IEnumerable<TransmissionFile> files, EncryptionProfile encryptionProfile)
        {

            List<TransmissionFile> encryptedFiles = new List<TransmissionFile>();
            foreach (var file in files)
            {

                TransmissionFile encryptedFile = await EncryptFileAsync(file, encryptionProfile);
                encryptedFiles.Add(encryptedFile);
            }
            return encryptedFiles;
        }

    }
}
