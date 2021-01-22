using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiThrottle;

namespace ems.Controllers
{
    [EnableCors("*", "*", "*")]
    [AllowAnonymous]
    [EnableThrottling]
    public class ValueController : ApiController
    {
        [Route("api/value")]
        [EnableThrottling]
        public IHttpActionResult Get()
        {
            string[] arr = { "value1", "value2" };
            return Ok(arr);
        }

        [DisableThrotting]
        [Route("api/value/{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok("value"+id);
        }
    }
}
