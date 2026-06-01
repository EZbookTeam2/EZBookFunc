using System.Linq;
using System.Web.Http;
using EZBook.Api.Models;

namespace EZBook.Api.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                var users = db.Users
                    .Select(user => new UserSummary
                    {
                        UsersId = user.UsersId,
                        Names = user.Names,
                        Passwords = user.Passwords,
                        Email = user.Email,
                        Department = user.Department,
                        StartDate = user.StartDate,
                        Nationality = user.Nationality,
                        Position = user.Position,
                        Code = user.Code,
                        Profilepic = user.Profilepic,
                    })
                    .ToList();

                return Ok(users);
            }
        }

        [HttpPut]
        public IHttpActionResult Put(Users value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.UsersId))
            {
                return BadRequest("User id is required.");
            }

            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                var entity = db.Users.FirstOrDefault(user => user.UsersId == value.UsersId);
                if (entity == null)
                {
                    return NotFound();
                }

                entity.Names = value.Names;
                entity.Passwords = value.Passwords;
                entity.Email = value.Email;
                entity.Department = value.Department;
                entity.StartDate = value.StartDate;
                entity.Nationality = value.Nationality;
                entity.Position = value.Position;
                entity.Profilepic = value.Profilepic;
                entity.Code = value.Code;

                db.SaveChanges();
            }

            return Ok("Updated");
        }
    }
}
