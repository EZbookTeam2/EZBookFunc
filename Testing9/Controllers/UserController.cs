using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    public class UserData
    {
        public string UsersId { get; set; }
        public string Names { get; set; }
        public string Passwords { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string StartDate { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Code { get; set; }
        public string Profilepic { get; set; }
    }

    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                List<UserData> User = (from u in db.Users
                                   select new UserData
                                   {
                                       UsersId = u.UsersId,
                                       Names = u.Names,
                                       Passwords = u.Passwords,
                                       Email = u.Email,
                                       Department = u.Department,
                                       StartDate = u.StartDate,
                                       Nationality = u.Nationality,
                                       Position = u.Position,
                                       Code = u.Code,
                                       Profilepic = u.Profilepic,
                                   }).ToList();
                return Ok(User);
            }
        }
        
    }
}
