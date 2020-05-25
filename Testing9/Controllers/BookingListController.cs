﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;
using Testing9.Utils;

namespace Testing9.Controllers
{
    [RoutePrefix("api/BookingList")]
    public class BookingListController : ApiController
    {
       
        [HttpPost]
        public IHttpActionResult Post(Booking value)
        {
            List<Booking> bookingList = new List<Booking>();
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                bookingList = db.Booking.Where(a => a.UsersId == value.UsersId && a.Status == "Approved").OrderBy(a => a.BookingId).ToList();
                
                return Ok(bookingList);
            }
        }
    }
}
