using System.Linq;
using System.Web.Http;
using Testing9.Infrastructure;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/BookingListAdmin")]
    public class BookingListAdminController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                var bookingList = (from user in db.Users
                                   join booking in db.Booking on user.UsersId equals booking.UsersId
                                   where booking.Status == BookingStatusValues.Approved
                                   orderby booking.BookingId descending
                                   select new AdminBookingItem
                                   {
                                       BookingId = booking.BookingId,
                                       UsersId = user.UsersId,
                                       RoomId = booking.RoomId,
                                       Name = booking.Name,
                                       Title = booking.Title,
                                       Location = booking.Location,
                                       Date = booking.Date,
                                       Time = booking.Time,
                                       Status = booking.Status,
                                       Username = user.Names
                                   }).ToList();

                return Ok(bookingList);
            }
        }
    }
}
