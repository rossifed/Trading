using Quantaventis.Trading.Modules.Transmission.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Services
{

    internal static class GpgCommandBuilder
    {
        public static string BuildGpgArguments(
            string homedir,
         string defaultKeyEmail,
         string recipientEmail,
         string? passphrase,
         string inputFile,
         string outputFile
      )
        {

            return BuildGpgArguments(homedir,defaultKeyEmail, new string[] { recipientEmail }, passphrase, inputFile, outputFile);
        }
        public static string BuildGpgArguments(string homedir,
         string defaultKeyEmail,
         string[] recipientEmails,
         string? passphrase,
          string inputFile,
         string outputFile
        )
        {
            var command = new StringBuilder();

            command.Append($" --batch --homedir \"{homedir}\" --yes --armor --encrypt --sign");
            command.AppendFormat($" --default-key {defaultKeyEmail}");

            foreach (var recipient in recipientEmails)
            {
                command.AppendFormat($" --recipient {recipient}");
            }

            if (passphrase != null)
                command.AppendFormat($" --passphrase \"{passphrase}\"");
            command.AppendFormat($" --pinentry-mode loopback");
            command.AppendFormat($" -o \"{outputFile}\" \"{inputFile}\"");
            
            return command.ToString();
        }


    }
}
