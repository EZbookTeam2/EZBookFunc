using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Forms;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/DeleteUser")]
    public class DeleteUserController : ApiController
    {
        ezbookdatabaseContext dbContext = new ezbookdatabaseContext();

        [HttpDelete]
        public IHttpActionResult DeleteByName([FromUri]string id = null)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("empty");
            }
            try
            {
                var data = from user in dbContext.Users
                           where user.UsersId == id
                           select user;
                Users obj = data.SingleOrDefault();
                dbContext.Users.Remove(obj);
                dbContext.SaveChanges();
                return Ok("Delete successfully");
            }
            catch (Exception Ex)
            {
                return Ok(Ex);
            }
        }
            
        
        }
}
