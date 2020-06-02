using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/ApproveBooking")]
    public class ApproveBookingController : ApiController
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
                old.Status = value.Status;
                dbContext.SaveChanges();
                return Ok("hello");
            }
            catch (Exception ex)
            {
                string message = "fail " + ex.Message;
                return Ok(message);

            }
        }
    }
}
