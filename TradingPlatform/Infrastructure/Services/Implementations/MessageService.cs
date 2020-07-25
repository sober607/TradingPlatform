using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradingPlatform.Infrastructure.Configuration;
using TradingPlatform.Infrastructure.Services.Interfaces;

namespace TradingPlatform.Infrastructure.Services.Implementations
{
    public class MessageService : IMessageService
    {
        public IConfiguration _configuration { get; set; }

        public TradingPlatformConfiguration _options { get; set; }

        public MessageService(IConfiguration configuration, IOptions<TradingPlatformConfiguration> options)
        {
            _configuration = configuration;
            _options = options.Value;
        }


        public async Task SendMessageAsync(string type, string text, string subject, string receiverData)
        {
            if (type == "email")
            {
                await this.SendEmailAsync(text, subject, receiverData);
            }
            else if (type == "sms")
            {
                //this.SendSms(text, receiverData); // To implement
            }
        }

        public async Task SendEmailAsync(string message, string subject, string receiverEmail)
        {
            //add email message
            MimeMessage email = new MimeMessage();
            var from = new MailboxAddress("Trading platform", _options.Notification.Email.SenderEmail);
            email.From.Add(from);

            var to = new MailboxAddress("", receiverEmail);
            email.To.Add(to);

            email.Subject = subject;

            // add email body
            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = message;
            email.Body = bodyBuilder.ToMessageBody();

            // send message
            using (SmtpClient client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, ce, e) => true;
                await client.ConnectAsync(_options.Notification.Email.SmtpServer, _options.Notification.Email.SmtpPort, true);
                await client.AuthenticateAsync(_options.Notification.Email.AuthenticationEmail, _options.Notification.Email.AuthenticationEmailPassword);
                await client.SendAsync(email);

                await client.DisconnectAsync(true);
            }
        }
    }
}
