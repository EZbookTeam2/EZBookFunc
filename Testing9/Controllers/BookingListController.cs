using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms.VisualStyles;
using Testing9.Models;
using Testing9.Utils;

namespace Testing9.Controllers
{
    [RoutePrefix("api/BookingList")]
    public class BookingListController : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Booking> bookingList = new List<Booking>();
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                bookingList = db.Booking.Where(a => a.Status == "Approve").OrderBy(a => a.BookingId).ToList();
                
                return Ok(bookingList);
            }
        }

        [HttpPost]

        public IHttpActionResult Post(Booking value)
        {
            if (!dbContext.Booking.Any(ID => ID.BookingId.Equals(value.BookingId)))
            {
                Booking temp = new Booking();
                temp.BookingId = value.BookingId;
                temp.UsersId = value.UsersId;
                temp.RoomId = value.RoomId;
                temp.Name = value.Name;
                temp.Title = value.Title;
                temp.Location = value.Location;
                temp.Date = value.Date;
                temp.Time = value.Time;
                temp.Status = "New";
                temp.StartTime = value.StartTime;
                temp.EndTime = value.EndTime;

                try
                {
                    dbContext.Add(temp);
                    dbContext.SaveChanges();
                    string message = "Added";
                    return Ok(message);
                }
                catch (Exception ex)
                {
                    string message = "Add Fail" + ex.Message;
                    return Ok(message);
                }
            }
            else
            {
                string message = "Booking name has been used";
                return Ok(message);
            }
        }
    }
}
