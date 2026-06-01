using System.Linq;
using System.Web.Http;
using Testing9.Infrastructure;
using Testing9.Models;

namespace Testing9.Controllers
{
    [RoutePrefix("api/cancelCheck")]
    public class cancelcheckController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                var cancelList = db.Cancellation
                    .Where(cancellation => cancellation.Status == CancellationStatusValues.PendingApproval)
                    .OrderBy(cancellation => cancellation.CancellationId)
                    .ToList();

                return Ok(cancelList);
            }
        }
    }
}
