using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessEntities.Character;
using BusinessServices.Character;
using BusinessServices.Staff;
using Identity;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MedApi.Controllers
{
    [Authorize]
    public class PatientController : ApiController
    {
        private readonly IPatientServices _patientServices;
        private readonly IStaffServices _staffServices;

        public PatientController(IPatientServices patientServices, IStaffServices staffServices)
        {
            _patientServices = patientServices;
            _staffServices = staffServices;
        }

        [ResponseType(typeof(List<PatientEntity>))]
        [Route("api/patient/")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            ApiUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApiUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            var staffEntity =_staffServices.GetStaffById(user.StaffId);
            var patients = _patientServices.GetPatients(staffEntity.ReferenceId);
            if (patients != null)
                return Request.CreateResponse(HttpStatusCode.OK, patients);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No patients found for this medic id");

        }
    }
}
