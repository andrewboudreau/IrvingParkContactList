using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using IrvingParkContactList.Services;

namespace IrvingParkContactList.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public async Task<ActionResult> TestEmail()
        {
            var email = new EmailService();

            var msg = email.DefaultMessage();
            msg.To.Add("andrewboudreau@gmail.com");
            msg.Body = "This is test.";
            msg.Subject = "Test " + DateTime.Now.ToShortTimeString();

            var smtpClient = email.DefaultSmtpClient();
            await smtpClient.SendMailAsync(msg);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Roles()
        {
            var data = new StringBuilder();

            data.AppendFormat("{0} : {1}<br />", "Identity Name", this.User.Identity.Name);
            data.AppendFormat("{0} : {1}<br />", "Identity", this.User.Identity.AuthenticationType);
            data.AppendFormat("{0} : {1}<br />", "IsAuthenticated", this.User.Identity.IsAuthenticated);
            return this.Content(data.ToString());
        }
    }
}