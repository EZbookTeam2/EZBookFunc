using System.Linq;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/ApproveBooking")]
    public class ApproveBookingController : ApiController
    {
        [HttpPut]
        public IHttpActionResult Put(Booking value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.BookingId) || string.IsNullOrWhiteSpace(value.Status))
            {
                return BadRequest("Booking id and status are required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                var booking = dbContext.Booking.SingleOrDefault(item => item.BookingId == value.BookingId);
                if (booking == null)
                {
                    return NotFound();
                }

                booking.Status = value.Status;
                dbContext.SaveChanges();
            }

            return Ok("Updated");
        }
    }
}
