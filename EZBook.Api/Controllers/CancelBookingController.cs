using System.Linq;
using System.Web.Http;
using EZBook.Api.Infrastructure;
using EZBook.Api.Models;

namespace EZBook.Api.Controllers
{
    [RoutePrefix("api/CancelBooking")]
    public class CancelBookingController : ApiController
    {
        [HttpPut]
        public IHttpActionResult Put(Booking value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.BookingId))
            {
                return BadRequest("Booking id is required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                var booking = dbContext.Booking.SingleOrDefault(item => item.BookingId == value.BookingId);
                if (booking == null)
                {
                    return NotFound();
                }

                booking.Status = BookingStatusValues.Cancelled;
                dbContext.SaveChanges();
            }

            return Ok("Successful");
        }
    }
}
