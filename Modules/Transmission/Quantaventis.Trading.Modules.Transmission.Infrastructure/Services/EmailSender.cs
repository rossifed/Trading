
using Quantaventis.Trading.Modules.Transmission.Infrastructure.Options;
using System.Net;
using System.Net.Mail;
using Quantaventis.Trading.Modules.Transmission.Domain.Model;
using Quantaventis.Trading.Modules.Transmission.Domain.Services;
namespace Quantaventis.Trading.Modules.Transmission.Infrastructure.Services
{

    internal class EmailSender : IEmailSender
    {
        private SmtpOptions SmtpOptions { get; }

        public EmailSender(SmtpOptions smtpOptions)
        {
            SmtpOptions = smtpOptions;
        }



        public async Task SendEmailAsync(IEnumerable<TransmissionFile> files, EmailConfiguration emailConfiguration)
        {
            var fromAddress = new MailAddress(SmtpOptions.SenderEmail);
            var toAddress = new MailAddress(emailConfiguration.Recipients);
            var smtp = new SmtpClient
            {
                Host = SmtpOptions.Host, // Your SMTP server address
                Port = SmtpOptions.Port,
                EnableSsl = SmtpOptions.EnableSsl,  // Use SSL (depends on your email provider)
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(SmtpOptions.CredentialEmail, SmtpOptions.CredentialPassword)
            };
            using (var message = new MailMessage())
            {
                message.Subject = emailConfiguration.EmailSubject;
                message.Body = emailConfiguration.MessageBody;
                message.From = fromAddress;
                var toRecipients = emailConfiguration.Recipients.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var toEmail in toRecipients)
                {
                    message.To.Add(toEmail.Trim());
                }
                if (emailConfiguration.AttachFile)
                {
                    foreach (var file in files)
                    {
                        message.Attachments.Add(new Attachment(file.FullPath));
                    }
                }
                await smtp.SendMailAsync(message);

            }
        }
    }
}
