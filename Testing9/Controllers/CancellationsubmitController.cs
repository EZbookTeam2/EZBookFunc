using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Testing9.Models;
using Testing9.Utils;

namespace Testing9.Controllers
{
    [RoutePrefix("api/Cancellationsubmit")]
    public class messageclass
    {
        public string Message { get; set; }
    }
        public class CancellationsubmitController : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();

        [HttpPost]
        public IHttpActionResult Post(Cancellation value)
        {

            var Id = int.Parse(dbContext.Cancellation.Max(z => z.CancellationId))+1;
            
            if (!dbContext.Cancellation.Any(cancel => cancel.BookingId.Equals(value.BookingId)))
            {
                Cancellation cancellation = new Cancellation();
                cancellation.CancellationId = Id.ToString();
                cancellation.BookingId = value.BookingId;
                cancellation.Reason = value.Reason;
                cancellation.Status = "New";
                try
                {
                    dbContext.Add(cancellation);
                    dbContext.SaveChanges();
                    string message = "Submit Successfully";
                    var example = new messageclass { Message = message };
                    return Ok(example);
                }
                catch (Exception ex)
                {
                    string message = "Submit Failed" + ex.Message;
                    var example = new messageclass { Message = message };
                    return Ok(example);
                

                }
            }
            else
            {
                string message = "You have made a cancellation for this Booking already, please wait for the approval";
                var example = new messageclass { Message = message };
                return Ok(example);
                
            }

        }
    }
}
