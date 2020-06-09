using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;
using System.Net.Mail;

namespace Testing9.Controllers
{
    [RoutePrefix("api/Email")]
    public class EmailController : ApiController
    {
        [HttpPost]
        public IHttpActionResult sendmail(EmailClass ec)
        {
            string subject = ec.subject;
            string body = ec.body;
            string to = ec.to;
            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("animeplaylist78@gmail.com");
            mm.To.Add(to);
            mm.Subject = subject;
            mm.Body = body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("animeplaylist78@gmail.com", "Abc123456_");
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(mm);
            return Ok();
        }
    }
}
