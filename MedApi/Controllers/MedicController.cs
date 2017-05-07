using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessEntities.Character;
using BusinessServices.Character;

namespace MedApi.Controllers
{
    public class MedicController : ApiController
    {
        private readonly IPatientServices _patientServices;

        public MedicController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

        [ResponseType(typeof(List<PatientEntity>))]
        [Route("api/medic/{id}/patients")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var patients = _patientServices.GetPatients(id);
            if (patients != null)
                return Request.CreateResponse(HttpStatusCode.OK, patients);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No patients found for this medic id");

        }
    }
}
