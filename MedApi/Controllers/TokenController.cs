using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MedApi.Controllers
{
    public class TokenController : ApiController
    {
        [Route("api/token")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetPatients()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
