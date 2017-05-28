using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessEntities.Character;
using BusinessEntities.Diagnosis;
using BusinessEntities.Examination;
using BusinessServices.Diagnosis;
using BusinessServices.Examination;
using BusinessServices.Staff;
using Identity;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MedApi.Controllers
{
    public class PatientController : ApiController
    {
        private readonly IExaminationServices _examinationServices;
        private readonly IDiagnosisServices _diagnosisServices;

        public PatientController(IExaminationServices examinationServices, IDiagnosisServices diagnosisServices)
        {
            _examinationServices = examinationServices;
            _diagnosisServices = diagnosisServices;
        }

        [ResponseType(typeof(List<ExaminationEntity>))]
        [Route("api/patient/{id}/examinations")]
        [HttpGet]
        public HttpResponseMessage GetExaminations(int id)
        {
            var examinations = _examinationServices.GetExaminationsForPatient(id);
            return Request.CreateResponse(HttpStatusCode.OK, examinations);
        }


        [ResponseType(typeof(DiagnosisEntity))]
        [Route("api/patient/{id}/diagnostics")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetDiagnostics(int id)
        {
            try
            {
                var diagnosis = _diagnosisServices.GetDiagnosticsForPatient(id);
                if (diagnosis != null)
                    return Request.CreateResponse(HttpStatusCode.OK, diagnosis);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not get diagnostics");
        }
    }
}
