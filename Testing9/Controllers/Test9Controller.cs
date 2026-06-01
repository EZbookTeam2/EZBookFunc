using System;
using System.Linq;
using System.Text;
using System.Web.Http;
using Testing9.Models;
using Testing9.Utils;

namespace Testing9.Controllers
{
    [RoutePrefix("api/test9")]
    public class Test9Controller : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("connected liao mou");
        }

        [HttpPost]
        public IHttpActionResult Post(Testing value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.Username) || string.IsNullOrWhiteSpace(value.Password))
            {
                return BadRequest("Username and password are required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                if (dbContext.Testing.Any(existingUser => existingUser.Username == value.Username))
                {
                    return Ok("Username has been used");
                }

                var testingUser = new Testing
                {
                    Username = value.Username,
                    Salt = Convert.ToBase64String(Common.GetRandomSalt(16)),
                };

                testingUser.Password = Convert.ToBase64String(Common.SaltHashPassword(
                    Encoding.ASCII.GetBytes(value.Password),
                    Convert.FromBase64String(testingUser.Salt)));

                dbContext.Add(testingUser);
                dbContext.SaveChanges();
            }

            return Ok("Registered liao");
        }
    }
}
