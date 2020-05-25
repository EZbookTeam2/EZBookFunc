using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    public class Data
    {
        public string CancelId { get; set; }
        public string BookingId { get; set; }
        public string RoomName { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Username { get; set; }
        public string Status { get; set; }
        public string Reason { get; set; }
        public List<string> CancellationList { get; set; }
    }
    [RoutePrefix("api/CancellationList")]
    public class CancellationListController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {

            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                List<Data> CancellationList = (from c in db.Cancellation
                                               join d in db.Booking
                                               on c.BookingId equals d.BookingId
                                               join e in db.Users on d.UsersId equals e.UsersId
                                               where(c.Status == "New")
                                               select new Data
                                               {
                                                   Username = e.Names,
                                                   CancelId = c.CancellationId,
                                                   BookingId = d.BookingId,
                                                   RoomName = d.Name,
                                                   Title = d.Title,
                                                   Status = c.Status,
                                                   Reason = c.Reason,
                                                   Location = d.Location,
                                                   Time = d.Time,
                                                   Date = d.Date,
                                               }).ToList();



                return Ok(CancellationList);
            }
        }
    }
}
