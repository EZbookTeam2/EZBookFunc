using System.Linq;
using System.Web.Http;
using Testing9.Infrastructure;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/BookingApplication")]
    public class BookingApplicationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                var bookingApplicationList = (from booking in db.Booking
                                              join user in db.Users on booking.UsersId equals user.UsersId
                                              where booking.Status == BookingStatusValues.PendingApproval
                                              select new BookingApplicationItem
                                              {
                                                  Username = user.Names,
                                                  BookingId = booking.BookingId,
                                                  UserId = booking.UsersId,
                                                  RoomName = booking.Name,
                                                  Title = booking.Title,
                                                  Status = booking.Status,
                                                  Location = booking.Location,
                                                  Time = booking.Time,
                                                  Date = booking.Date,
                                              }).ToList();

                return Ok(bookingApplicationList);
            }
        }
    }
}
