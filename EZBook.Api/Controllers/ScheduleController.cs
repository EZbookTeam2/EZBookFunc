using System.Linq;
using System.Web.Http;
using EZBook.Api.Infrastructure;
using EZBook.Api.Models;

namespace EZBook.Api.Controllers
{
    [RoutePrefix("api/Schedule")]
    public class ScheduleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                var scheduleList = (from user in db.Users
                                    join booking in db.Booking on user.UsersId equals booking.UsersId
                                    join room in db.Room on booking.RoomId equals room.RoomId
                                    where booking.Status == BookingStatusValues.Approved
                                    select new ScheduleItem
                                    {
                                        Roompic = room.Image,
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

                return Ok(scheduleList);
            }
        }
    }
}
