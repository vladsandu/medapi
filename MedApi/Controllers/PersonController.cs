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
using BusinessServices;
using BusinessServices.Character;
using BusinessServices.Examination;
using Identity;
using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace MedApi.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonServices _personServices;
        private readonly IExaminationServices _examinationServices;

        public PersonController(IPersonServices personServices, IExaminationServices examinationServices)
        {
            _personServices = personServices;
            _examinationServices = examinationServices;
        }

        [ResponseType(typeof(PersonEntity))]
        [Route("api/person")]
        public HttpResponseMessage Get(string cnp)
        {
            if (cnp.Length != 13)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "CNP length incorrect");
            var person = _personServices.GetPersonByCnp(cnp);
            if (person != null)
                return Request.CreateResponse(HttpStatusCode.OK, person);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No person found for this cnp");
        }


        [ResponseType(typeof(List<ExaminationEntity>))]
        [Authorize]
        [Route("api/person/examinations")]
        public HttpResponseMessage GetExaminations()
        {
            var user = HttpContext.Current.GetOwinContext().GetUserManager<ApiUserManager>().FindById(HttpContext.Current.User.Identity.GetUserId());
            
            var cnp = user.UserName;
            var examinations = _examinationServices.GetExaminationsForPerson(cnp);
            if (examinations != null)
                return Request.CreateResponse(HttpStatusCode.OK, examinations);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No examinations found for this person");
        }
    }
}
