using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessEntities.Diagnosis;
using BusinessServices.Diagnosis;

namespace MedApi.Controllers
{
    public class DiagnosisController : ApiController {
        private IConditionServices _conditionServices;

        public DiagnosisController(IConditionServices conditionServices)
        {
            _conditionServices = conditionServices;
        }

        [ResponseType(typeof(List<ConditionEntity>))]
        [Route("api/diagnosis/conditions")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetConditions()
        {
            var conditions = _conditionServices.GetConditions();
            if (conditions != null)
                return Request.CreateResponse(HttpStatusCode.OK, conditions);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No conditions found");
        }

    }
}
