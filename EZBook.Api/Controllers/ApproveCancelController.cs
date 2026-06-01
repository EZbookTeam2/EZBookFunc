using System.Linq;
using System.Web.Http;
using Testing9.Infrastructure;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/ApproveCancel")]
    public class ApproveCancelController : ApiController
    {
        [HttpPut]
        public IHttpActionResult Put(Cancellation value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.BookingId) || string.IsNullOrWhiteSpace(value.Status))
            {
                return BadRequest("Booking id and status are required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                var cancellation = dbContext.Cancellation
                    .SingleOrDefault(item => item.BookingId == value.BookingId && item.Status == CancellationStatusValues.PendingApproval);

                if (cancellation == null)
                {
                    return NotFound();
                }

                cancellation.Status = value.Status;

                if (value.Status == CancellationStatusValues.Approved)
                {
                    var booking = dbContext.Booking.SingleOrDefault(item => item.BookingId == value.BookingId);
                    if (booking == null)
                    {
                        return NotFound();
                    }

                    booking.Status = BookingStatusValues.Cancelled;
                }

                dbContext.SaveChanges();
            }

            return Ok(value.Status == CancellationStatusValues.Approved
                ? CancellationStatusValues.Approved
                : CancellationStatusValues.Disapproved);
        }
    }
}
