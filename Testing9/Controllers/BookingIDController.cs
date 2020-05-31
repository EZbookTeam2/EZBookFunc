using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/BookingID")]

    public class BookingIDController : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Booking> bookingList = new List<Booking>();
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                bookingList = db.Booking.ToList();

                return Ok(bookingList);
            }
        }
    }
}
