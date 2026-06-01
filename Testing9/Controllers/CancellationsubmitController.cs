using System.Linq;
using System.Net;
using System.Web.Http;
using Testing9.Infrastructure;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/Cancellationsubmit")]
    public class CancellationsubmitController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(Cancellation value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.BookingId))
            {
                return BadRequest("Booking id is required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                var existingCancellation = dbContext.Cancellation.Any(cancel =>
                    cancel.BookingId == value.BookingId && cancel.Status == CancellationStatusValues.PendingApproval);

                if (existingCancellation)
                {
                    return Content(HttpStatusCode.Conflict, new ApiMessage
                    {
                        Message = "You have made a cancellation for this booking already, please wait for the approval"
                    });
                }

                var nextId = dbContext.Cancellation
                    .Select(cancellation => cancellation.CancellationId)
                    .DefaultIfEmpty(0)
                    .Max() + 1;

                var cancellationToCreate = new Cancellation
                {
                    CancellationId = nextId,
                    BookingId = value.BookingId,
                    Reason = value.Reason,
                    Status = CancellationStatusValues.PendingApproval
                };

                dbContext.Add(cancellationToCreate);
                dbContext.SaveChanges();

                return Ok(new ApiMessage { Message = "Submit Successfully" });
            }
        }
    }
}
