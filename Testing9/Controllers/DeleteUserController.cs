using System.Linq;
using System.Web.Http;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/DeleteUser")]
    public class DeleteUserController : ApiController
    {
        [HttpDelete]
        public IHttpActionResult DeleteByName([FromUri] string id = null)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("User id is required.");
            }

            using (ezbookdatabaseContext dbContext = new ezbookdatabaseContext())
            {
                var user = dbContext.Users.SingleOrDefault(item => item.UsersId == id);
                if (user == null)
                {
                    return NotFound();
                }

                dbContext.Users.Remove(user);
                dbContext.SaveChanges();
            }

            return Ok("Delete successfully");
        }
    }
}
