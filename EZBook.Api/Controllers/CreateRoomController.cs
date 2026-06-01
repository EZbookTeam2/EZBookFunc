using System.Linq;
using System.Net;
using System.Web.Http;
using EZBook.Api.Models;

namespace EZBook.Api.Controllers
{
    [RoutePrefix("api/createRoom")]
    public class CreateRoomController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                var rooms = dbContext.Room
                    .Select(room => new RoomSummary
                    {
                        RoomId = room.RoomId,
                        Name = room.Name,
                        Location = room.Location,
                        Image = room.Image,
                    })
                    .ToList();

                return Ok(rooms);
            }
        }

        [HttpPost]
        public IHttpActionResult Post(Room value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.Name))
            {
                return BadRequest("Room name is required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                if (dbContext.Room.Any(room => room.Name == value.Name))
                {
                    return Content(HttpStatusCode.Conflict, "Room name has already been used.");
                }

                dbContext.Add(new Room
                {
                    Name = value.Name,
                    RoomId = value.RoomId,
                    Location = value.Location,
                    Image = value.Image
                });
                dbContext.SaveChanges();

                return Ok("Registered");
            }
        }
    }
}
