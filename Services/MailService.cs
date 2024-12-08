using System.Net;
using System.Net.Mail;
using AsmrsBackend.Services;
namespace AsmrsBackend.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration cofiguration;
        public EmailService(IConfiguration configuration)
        {
            this.cofiguration = configuration;
        }
        public async Task<bool> SendEmailAsync(string email, string subject, string message)
        {
            bool status = false;
            try
            {
                string eSecretKey = cofiguration.GetValue<string>("AppSettings:SecretKey");
                string eFrom = cofiguration.GetValue<string>("AppSettings:EmailSettings:From");
                string eSmtpServer = cofiguration.GetValue<string>("AppSettings:EmailSettings:SmtpServer");
                int eport = cofiguration.GetValue<int>("AppSettings:EmailSettings:Port");
                bool eEnableSSL = cofiguration.GetValue<bool>("AppSettings:EmailSettings:EnableSSL");
                
                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress(eFrom),
                    Subject = subject,
                    Body = message
                };
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(email);
                SmtpClient smtpClient = new SmtpClient(eSmtpServer)
                {
                    Port = eport,
                    Credentials = new NetworkCredential(eFrom, eSecretKey),
                    EnableSsl = eEnableSSL
                };
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("mail sent");
                status = true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                status = false;
            }
            return status;
        }
    }
}