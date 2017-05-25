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
    public class ExaminationController : ApiController
    {
        private readonly IExaminationServices _examinationServices;
        private readonly IStaffServices _staffServices;
        private readonly IDiagnosisServices _diagnosisServices;

        public ExaminationController(IExaminationServices examinationServices, IStaffServices staffServices, IDiagnosisServices diagnosisServices)
        {
            _examinationServices = examinationServices;
            _staffServices = staffServices;
            _diagnosisServices = diagnosisServices;
        }

        [ResponseType(typeof(List<ExaminationTypeEntity>))]
        [Route("api/examination/types")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetExaminationTypes()
        {
            var examinations = _examinationServices.GetExaminationTypes();
            if (examinations != null)
                return Request.CreateResponse(HttpStatusCode.OK, examinations);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No examinations types found");
        }

        [ResponseType(typeof(List<ExaminationTypeEntity>))]
        [Route("api/examination/")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage AddExamination(int patientId, string examinationType)
        {
            try
            {
                var examination = _examinationServices.AddExaminationForPatient(patientId, examinationType);
                if (examination != null)
                    return Request.CreateResponse(HttpStatusCode.OK, examination);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No examinations types found");
        }


        [ResponseType(typeof(DiagnosisEntity))]
        [Route("api/examination/diagnosis")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage AddDiagnosis(DiagnosisAddRequest diagnosisAddRequest)
        {
            try
            {
                var diagnosis = _diagnosisServices.AddDiagnosis(diagnosisAddRequest);
                if (diagnosis != null)
                    return Request.CreateResponse(HttpStatusCode.OK, diagnosis);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e.Message);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Could not add diagnosis");
        }

        [ResponseType(typeof(DiagnosisEntity))]
        [Route("api/examination/diagnostics")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetDiagnostics(int examinationId)
        {
            try
            {
                var diagnosis = _diagnosisServices.GetDiagnosticsForExamination(examinationId);
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
