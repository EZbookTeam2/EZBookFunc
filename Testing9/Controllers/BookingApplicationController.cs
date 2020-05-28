using System;
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
    public class BookingAppilcation
    {
        public string BookingId { get; set; }
        public string RoomName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public List<string> BookingApplication { get; set; }
    }
    [RoutePrefix("api/BookingApplication")]
    public class BookingApplicationController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                List<BookingAppilcation> BookingApplicationList = (from  d in db.Booking
                                               join e in db.Users on d.UsersId equals e.UsersId
                                               where (d.Status == "New")
                                               select new BookingAppilcation
                                               {
                                                   Username = e.Names,
                                                   BookingId = d.BookingId,
                                                   RoomName = d.Name,
                                                   Title = d.Title,
                                                   Status = d.Status,
                                                   Location = d.Location,
                                                   Time = d.Time,
                                                   Date = d.Date,
                                               }).ToList();



                return Ok(BookingApplicationList);
            }
        }
    }
}
