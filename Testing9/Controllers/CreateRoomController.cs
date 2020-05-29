using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    public class RoomData
    {
        public string RoomId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Image { get; set; }
    }

    [RoutePrefix("api/createRoom")]
    public class CreateRoomController : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();

        [HttpGet]

        public IHttpActionResult Get()
        {
            List<RoomData> Room = (from r in dbContext.Room
                                   select new RoomData
                                   {
                                       RoomId = r.RoomId,
                                       Name = r.Name,
                                       Location = r.Location,
                                       Image = r.Image,
                                   }).ToList();
            return Ok(Room);
        }

        [HttpPost]

        public IHttpActionResult Post(Room value)
        {
            if (!dbContext.Room.Any(RoomName => RoomName.Name.Equals(value.Name)))
            {
                Room temp = new Room();
                temp.Name = value.Name;
                temp.RoomId = value.RoomId;
                temp.Location = value.Location;
                temp.Image = value.Image;

                try
                {
                    dbContext.Add(temp);
                    dbContext.SaveChanges();
                    string message = "Registered";
                    return Ok(message);
                }
                catch (Exception ex)
                {
                    string message = "Register Fail" + ex.Message;
                    return Ok(message);
                }
            }
            else
            {
                string message = "Room name has been used";
                return Ok(message);
            }
        }
    }
}