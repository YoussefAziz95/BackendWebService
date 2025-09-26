using Application.Contracts.Infrastructures;
using Application.Contracts.Persistence;
using Application.Model.EmailDto;
using Application.Wrappers;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
namespace Application.Utilities
{
    /// <summary>
    /// Services for sending emails using SMTP.
    /// </summary>
    public sealed class EmailService : ResponseHandler, IEmailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Sends an email using the provided email details.
        /// </summary>
        /// <param name="emailDto">EmailDto details including sender, recipients, subject, and body.</param>
        /// <returns>True if the email was sent successfully; otherwise, false.</returns>
        private bool SendEmail(EmailDto emailDto)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(EmailConfiguration.CompanyName, EmailConfiguration.From));
            message.Body = new TextPart("html") { Text = EmailConfiguration.generateTemplate(emailDto.To, emailDto.Body) };
            message.Subject = emailDto.Subject.Replace("\r\n", " ");
            List<string> _ToAddress = emailDto.To.Split(';').ToList();
            foreach (var item in _ToAddress)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    message.To.Add(new MailboxAddress("", item));
                }
            }

            if (emailDto.CC.Trim().Length > 0)
            {
                foreach (string addr in emailDto.CC.Split(';'))
                {
                    if (!string.IsNullOrEmpty(addr))
                        message.Cc.Add(new MailboxAddress("", addr));
                }
            }
            if (emailDto.BCC.Trim().Length > 0)
            {
                foreach (string addr in emailDto.BCC.Split(';'))
                {
                    if (!string.IsNullOrEmpty(addr))
                        message.Bcc.Add(new MailboxAddress("", addr));
                }
            }
            using (SmtpClient smtp = new SmtpClient())
            {
                Console.WriteLine("Token " + emailDto.Body);
                smtp.Connect(EmailConfiguration.GmailHost, EmailConfiguration.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(EmailConfiguration.From, EmailConfiguration.Password);
                smtp.Send(message);
                smtp.Disconnect(true);
                return true;
            }
        }
        private int Add(EmailLog request)
        {
            _unitOfWork.GenericRepository<EmailLog>().Add(request);
            var result = _unitOfWork.Save();
            return result;
        }

        public int Send(EmailDto emailDto)
        {
            var reuslt = SendEmail(emailDto);

            if (reuslt)
            {
                var emailRequest = new EmailLog
                {
                    Subject = emailDto.Subject,
                    Body = emailDto.Body,
                    SentAt = DateTime.Now,
                    SenderId = 1 // company.BaseCompanyId ?? 1,
                };
                return Add(emailRequest);
            }
            return -1;
        }
    }
}
