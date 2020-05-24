using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Testing9.Models;
using Testing9.Utils;

namespace Testing9.Controllers
{
    [RoutePrefix("api/test9")]
    public class Test9Controller : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok("connected liao mou");
        }

        [HttpPost]
        public IHttpActionResult Post(Testing value)
        {
            if (!dbContext.Testing.Any(User => User.Username.Equals(value.Username)))
            {
                Testing user = new Testing();
                user.Username = value.Username;
                user.Salt = Convert.ToBase64String(Common.GetRandomSalt(16));
                user.Password = Convert.ToBase64String(Common.SaltHashPassword(
                   Encoding.ASCII.GetBytes(value.Password),
                   Convert.FromBase64String(user.Salt)));
                try
                {
                    dbContext.Add(user);
                    dbContext.SaveChanges();
                    string message = "Registered liao";
                    return Ok(message);
                }
                catch (Exception ex)
                {
                    string message = "Register failed " + ex.Message;
                    return Ok(message);

                }
            }
            else
            {
                string message = "Username has been used";
                return Ok(message);
            }

        }
    }
}
