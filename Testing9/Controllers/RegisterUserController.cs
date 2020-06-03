using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/RegisterUser")]
    public class messageclass2
    {
        public string Message { get; set; }
    }
    public class RegisterUserController : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();

        [HttpPost]
        public IHttpActionResult Post(Users value)
        {

            var Id = int.Parse(dbContext.Users.Max(z => z.UsersId)) + 1;
            if (!dbContext.Users.Any(x => x.Email.Equals(value.Email)))
            {
                Users Nuser = new Users();
                Nuser.UsersId = Id.ToString();
                Nuser.Names = value.Names;
                Nuser.Passwords = value.Passwords;
                Nuser.Email = value.Email;
                Nuser.Department = value.Department;
                Nuser.StartDate = value.StartDate;
                Nuser.Nationality = value.Nationality;
                Nuser.Position = value.Position;
                Nuser.Profilepic = value.Profilepic;
                try
                {
                    dbContext.Add(Nuser);
                    dbContext.SaveChanges();
                    string message = "Registered";
                    var example = new messageclass { Message = message };
                    return Ok(example);
                }
                catch (Exception ex)
                {
                    string message = "Submit Failed" + ex.Message;
                    var example = new messageclass { Message = message };
                    return Ok(example);


                }
            }
            else
            {
                string message = "The Email has been used";
                var example = new messageclass { Message = message };
                return Ok(example);

            }
        }
    }
}
