using System.Net;
using System.Net.Mail;
using System.Web.Http;
using Testing9.Infrastructure;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/Email")]
    public class EmailController : ApiController
    {
        [HttpPost]
        public IHttpActionResult SendMail(EmailClass email)
        {
            if (email == null
                || string.IsNullOrWhiteSpace(email.to)
                || string.IsNullOrWhiteSpace(email.subject)
                || string.IsNullOrWhiteSpace(email.body))
            {
                return BadRequest("To, subject, and body are required.");
            }

            var smtpSettings = AppConfiguration.GetSmtpSettings();
            if (!smtpSettings.IsConfigured)
            {
                return Content(HttpStatusCode.InternalServerError, new ApiMessage
                {
                    Message = "SMTP settings are not configured. Update the Smtp.* values in Web.config."
                });
            }

            using (var message = new MailMessage())
            using (var smtpClient = new SmtpClient(smtpSettings.Host))
            {
                message.From = new MailAddress(smtpSettings.FromAddress);
                message.To.Add(email.to);
                message.Subject = email.subject;
                message.Body = email.body;
                message.IsBodyHtml = false;

                smtpClient.EnableSsl = smtpSettings.EnableSsl;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);
                smtpClient.Port = smtpSettings.Port;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);
            }

            return Ok(new ApiMessage { Message = "Email sent." });
        }
    }
}
