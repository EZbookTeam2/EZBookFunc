using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using Testing9.Models;
using Testing9.Utils;

namespace Testing9.Controllers
{
    public class cancelbooking
    {
        public string BookingId { get; set; }
        public string UsersId { get; set; }
        public string RoomId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Status { get; set; }
        public string Username { get; set; }

        public List<string> BookingList { get; set; }
    }
    [RoutePrefix("api/BookingListAdmin")]
    public class BookingListAdminController : ApiController
    {

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Booking> bookingList = new List<Booking>();
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                List<cancelbooking> BookingList = (from b in db.Users
                                                   join c in db.Booking
                                                   on b.UsersId equals c.UsersId
                                                   where (c.Status == "Approved")
                                                   orderby (c.BookingId) descending
                                                   select new cancelbooking
                                                   {
                                                   
                                                       BookingId = c.BookingId,
                                                       UsersId = b.UsersId,
                                                       RoomId = c.RoomId,
                                                       Name = c.Name,
                                                       Title = c.Title,
                                                       Location = c.Location,
                                                       Date = c.Date,
                                                       Time = c.Time,
                                                       Status = c.Status,
                                                       Username = b.Names
                                                   }).ToList();

                return Ok(BookingList);
            }
        }
    }
}
