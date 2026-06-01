using System.Linq;
using System.Net;
using System.Web.Http;
using Testing9.Infrastructure;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/BookingID")]
    public class BookingIDController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                var bookingList = db.Booking
                    .OrderBy(booking => booking.BookingId)
                    .ToList();

                return Ok(bookingList);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Booking value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.BookingId))
            {
                return BadRequest("Booking id is required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                if (dbContext.Booking.Any(booking => booking.BookingId == value.BookingId))
                {
                    return Content(HttpStatusCode.Conflict, "Booking id has already been used.");
                }

                dbContext.Add(BookingFactory.CreateNewBooking(value));
                dbContext.SaveChanges();

                return Ok("Added");
            }
        }
    }
}
