using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class EncryptionProfile
    {
        internal int EncryptionProfileId { get; }

        internal string PublicKeyRecipient { get;  } 

        internal string PrivateKeyRecipient { get;  } 

        internal string? Passphrase { get; }

        internal bool Sign { get;  }

        internal string ExcryptedFileExtension { get;  }

        public EncryptionProfile(int encryptionProfileId,
            string publicKeyRecipient, 
            string privateKeyRecipient,
            string? passphrase, 
            bool sign, 
            string excryptedFileExtension)
        {
            EncryptionProfileId = encryptionProfileId;
            PublicKeyRecipient = publicKeyRecipient;
            PrivateKeyRecipient = privateKeyRecipient;
            Passphrase = passphrase;
            Sign = sign;
            ExcryptedFileExtension = excryptedFileExtension;
        }
    }
}
