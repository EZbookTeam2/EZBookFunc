using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;
namespace Testing9.Controllers
{
    [RoutePrefix("api/ApproveCancel")]

    public class ApproveCancelController : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();
        [HttpPut]
        public IHttpActionResult Put(Cancellation value)
        {
            try
            {
                var data = from b in dbContext.Cancellation
                           where b.BookingId == value.BookingId && b.Status.Equals("New")
                           select b;
                Cancellation old = data.SingleOrDefault();
                old.Status = value.Status;
                dbContext.SaveChanges();
                try
                {   if(value.Status == "Approved") {
                        var data2 = from b2 in dbContext.Booking
                                   where b2.BookingId == value.BookingId
                                   select b2;
                        Booking old2 = data2.SingleOrDefault();
                        old2.Status = "Cancelled";
                        dbContext.SaveChanges();
                        return Ok("Approved");}
                    else { 

                        return Ok("Dispproved"); }

                    

                }
                catch (Exception ex2) {
                    return Ok("fail2" + ex2.Message);
                }
            }
            catch (Exception ex)
            {
                string message = "fail " + ex.Message;
                return Ok(message);

            }
        }
    }
}
