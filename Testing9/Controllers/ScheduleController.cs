using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    public class schedule
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
        public string Roompic { get; set; }
        public List<string> BookingList { get; set; }
    }
    [RoutePrefix("api/Schedule")]
    public class ScheduleController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<schedule> schedulelists = new List<schedule>();
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                List<schedule> schedulelist = (from b in db.Users
                                                   join c in db.Booking
                                                   on b.UsersId equals c.UsersId
                                                   join e in db.Room on c.RoomId equals e.RoomId
                                                   where (c.Status == "Approve")
                                                   select new schedule
                                                   {
                                                       Roompic = e.Image,
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

                return Ok(schedulelist);
            }
        }
    }
}
