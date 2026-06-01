using System.Linq;
using System.Web.Http;
using Testing9.Infrastructure;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/CancellationList")]
    public class CancellationListController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                var cancellationList = (from cancellation in db.Cancellation
                                        join booking in db.Booking on cancellation.BookingId equals booking.BookingId
                                        join user in db.Users on booking.UsersId equals user.UsersId
                                        where cancellation.Status == CancellationStatusValues.PendingApproval
                                        select new CancellationQueueItem
                                        {
                                            Username = user.Names,
                                            CancelId = cancellation.CancellationId,
                                            BookingId = booking.BookingId,
                                            RoomName = booking.Name,
                                            Title = booking.Title,
                                            Status = cancellation.Status,
                                            Reason = cancellation.Reason,
                                            Location = booking.Location,
                                            Time = booking.Time,
                                            Date = booking.Date,
                                        }).ToList();

                return Ok(cancellationList);
            }
        }
    }
}
