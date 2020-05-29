using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing9.Models;
using Testing9.Utils;
namespace Testing9.Controllers
{
    [RoutePrefix("api/cancelCheck")]
    public class cancelcheckController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Cancellation> cancelList = new List<Cancellation>();
            using (ezbookdatabaseContext db = new ezbookdatabaseContext())
            {
                cancelList = db.Cancellation.Where(a => a.Status == "New").OrderBy(a => a.CancellationId).ToList();

                return Ok(cancelList);
            }
        }
    }
}
