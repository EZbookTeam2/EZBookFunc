using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/CancelBooking")]
    public class CancelBookingController : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();
        [HttpPut]
        public IHttpActionResult Put(Booking value)
        {
            try
            {
                var data = from b in dbContext.Booking
                           where b.BookingId == value.BookingId
                           select b;
                Booking old = data.SingleOrDefault();
                old.Status = "Cancelled";
                dbContext.SaveChanges();
                return Ok("Successful");
            }
            catch (Exception ex)
            {
                string message = "fail " + ex.Message;
                return Ok(message);

            }
        }
    }
}
