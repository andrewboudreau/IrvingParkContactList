using System.Configuration;

using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace IrvingParkContactList.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return this.ConfigureEmailAsync(message);
        }

        public MailMessage DefaultMessage()
        {
            var message = new MailMessage
            {
                From =
                    new MailAddress(
                    ConfigurationManager.AppSettings["MailAccountEmail"],
                    ConfigurationManager.AppSettings["MailAccountName"])
            };

            return message;
        }

        public SmtpClient DefaultSmtpClient()
        {
            if (ConfigurationManager.AppSettings["MailAccountSmtpPort"] == null)
            {
            throw new ConfigurationErrorsException("AppSetting.MailAccountSmtpPort is a required integer");    
            }

            var credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["MailAccount"],
                ConfigurationManager.AppSettings["MailPassword"]);

            var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["MailAccountSmtp"], int.Parse(ConfigurationManager.AppSettings["MailAccountSmtpPort"]))
                                 {
                                     Credentials = credentials,
                                     EnableSsl = false
                                 };

            return smtpClient;
        }

        private Task ConfigureEmailAsync(IdentityMessage message)
        {
            var myMessage = this.DefaultMessage();

            myMessage.To.Add(message.Destination);
            myMessage.Subject = message.Subject;

            myMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Plain));
            myMessage.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Html));

            var smtpClient = this.DefaultSmtpClient();

            return smtpClient.SendMailAsync(myMessage);
        }
    }
}