using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessEntities.Character;
using BusinessEntities.Examination;
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

        public ExaminationController(IExaminationServices examinationServices, IStaffServices staffServices)
        {
            _examinationServices = examinationServices;
            _staffServices = staffServices;
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
    }
}
