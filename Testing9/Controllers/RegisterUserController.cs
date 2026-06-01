using System.Linq;
using System.Net;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/RegisterUser")]
    public class RegisterUserController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(Users value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.Email))
            {
                return BadRequest("Email is required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                if (dbContext.Users.Any(user => user.Email == value.Email))
                {
                    return Content(HttpStatusCode.Conflict, new ApiMessage { Message = "The Email has been used" });
                }

                var nextId = dbContext.Users
                    .AsEnumerable()
                    .Select(user =>
                    {
                        int parsedId;
                        return int.TryParse(user.UsersId, out parsedId) ? parsedId : 0;
                    })
                    .DefaultIfEmpty(0)
                    .Max() + 1;

                var userToCreate = new Users
                {
                    UsersId = nextId.ToString(),
                    Names = value.Names,
                    Passwords = value.Passwords,
                    Email = value.Email,
                    Department = value.Department,
                    StartDate = value.StartDate,
                    Nationality = value.Nationality,
                    Position = value.Position,
                    Profilepic = value.Profilepic,
                    Code = value.Code
                };

                dbContext.Add(userToCreate);
                dbContext.SaveChanges();

                return Ok(new ApiMessage { Message = "Registered" });
            }
        }
    }
}
