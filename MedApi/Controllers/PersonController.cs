using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessEntities.Character;
using BusinessServices;
using BusinessServices.Character;

namespace MedApi.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonServices _personServices;

        public PersonController(IPersonServices personServices, IPatientServices patientServices)
        {
            _personServices = personServices;
        }

        [ResponseType(typeof(PersonEntity))]
        public HttpResponseMessage Get(string cnp)
        {
            if (cnp.Length != 13)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "CNP length incorrect");
            var nationality = _personServices.GetItemByCnp(cnp);
            if (nationality != null)
                return Request.CreateResponse(HttpStatusCode.OK, nationality);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No person found for this cnp");

        }
    }
}
