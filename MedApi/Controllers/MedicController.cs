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
using BusinessServices.Character;
using BusinessServices.Examination;
using BusinessServices.Staff;
using Identity;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MedApi.Controllers
{
    public class MedicController : ApiController
    {
        private readonly IPatientServices _patientServices;
        private readonly IExaminationServices _examinationServices;
        private readonly IStaffServices _staffServices;

        public MedicController(IPatientServices patientServices, IExaminationServices examinationServices, IStaffServices staffServices)
        {
            _patientServices = patientServices;
            _examinationServices = examinationServices;
            _staffServices = staffServices;
        }

        [ResponseType(typeof(List<PatientEntity>))]
        [Route("api/medic/patients")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetPatients()
        {
            ApiUser user = HttpContext.Current.GetOwinContext().GetUserManager<ApiUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());
            var staffEntity = _staffServices.GetStaffById(user.StaffId);
            var patients = _patientServices.GetPatients(staffEntity.ReferenceId);
            if (patients != null)
                return Request.CreateResponse(HttpStatusCode.OK, patients);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No patients found for this medic id");
        }

        [ResponseType(typeof(List<ExaminationEntity>))]
        [Route("api/medic/examinations")]
        [HttpGet]
        [Authorize]
        public HttpResponseMessage GetExaminations()
        {
            ApiUser user = HttpContext.Current.GetOwinContext().GetUserManager<ApiUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());
            var staffEntity = _staffServices.GetStaffById(user.StaffId);
            var examinations = _examinationServices.GetExaminationsForMedic(staffEntity.ReferenceId);
            if (examinations != null)
                return Request.CreateResponse(HttpStatusCode.OK, examinations);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No examinations found for this medic id");
        }


        [ResponseType(typeof(PatientEntity))]
        [Route("api/medic/patient")]
        [HttpPost]
        [Authorize]
        public HttpResponseMessage AddPatient(string cnp)
        {
            ApiUser user = HttpContext.Current.GetOwinContext().GetUserManager<ApiUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());
            var staffEntity = _staffServices.GetStaffById(user.StaffId);
            var patient = _patientServices.AddPatient(staffEntity.ReferenceId, cnp);
            if (patient != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, patient);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not add patient");
        }
    }
}
