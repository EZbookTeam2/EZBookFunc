using System.Linq;
using System.Web.Http;
using EZBook.Api.Infrastructure;
using EZBook.Api.Models;

namespace EZBook.Api.Controllers
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
