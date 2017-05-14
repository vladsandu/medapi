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
    public class PatientController : ApiController
    {
        private readonly IExaminationServices _examinationServices;
        
        public PatientController(IExaminationServices examinationServices)
        {
            _examinationServices = examinationServices;
        }

        [ResponseType(typeof(List<ExaminationEntity>))]
        [Route("api/patient/{id}/examinations")]
        [HttpGet]
        public HttpResponseMessage GetExaminations(int id)
        {
            var examinations = _examinationServices.GetExaminationsForPatient(id);
            return Request.CreateResponse(HttpStatusCode.OK, examinations);
        }
    }
}
