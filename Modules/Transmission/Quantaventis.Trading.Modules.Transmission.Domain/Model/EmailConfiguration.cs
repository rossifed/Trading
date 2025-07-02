using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantaventis.Trading.Modules.Transmission.Domain.Model
{
    internal class EmailConfiguration
    {

        internal string Recipients { get;  }

        internal string EmailSubject { get;  }

        internal string? MessageBody { get;  }

        internal bool AttachFile { get;  }

        public EmailConfiguration(string recipients, string emailSubject, string? messageBody, bool attachFile)
        {
            Recipients = recipients;
            EmailSubject = emailSubject;
            MessageBody = messageBody;
            AttachFile = attachFile;
        }


    }
}
