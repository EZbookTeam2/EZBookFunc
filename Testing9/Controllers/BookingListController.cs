using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;
using Testing9.Utils;

namespace Testing9.Controllers
{
    [RoutePrefix("api/BookingList")]
    public class BookingListController : ApiController
    {
       
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Booking> bookingList = new List<Booking>();
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                bookingList = db.Booking.OrderBy(a => a.BookingId).ToList();
                
                return Ok(bookingList);
            }
        }
    }
}
