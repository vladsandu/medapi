using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities.Character;
using BusinessServices;

namespace MedApi.Controllers
{
    public class NationalityController : ApiController
    {
        private readonly IGenericServices<NationalityEntity> _nationalityServices;

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public NationalityController(IGenericServices<NationalityEntity> nationalityServices)
        {
            _nationalityServices = nationalityServices;
        }
        
        // GET api/values
        public HttpResponseMessage Get()
        {
            var nationalities = _nationalityServices.GetAllItems();
            if (nationalities != null)
            {
                var nationalityEntities = nationalities as List<NationalityEntity> ?? nationalities.ToList();
                if (nationalityEntities.Any())
                    return Request.CreateResponse(HttpStatusCode.OK, nationalityEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nationalities not found");
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            var nationality = _nationalityServices.GetItemById(id);
            if (nationality != null)
                return Request.CreateResponse(HttpStatusCode.OK, nationality);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No nationality found for this id");

        }

        // POST api/values
        public int Post([FromBody]NationalityEntity value)
        {
            return _nationalityServices.CreateItem(value);
        }

        // PUT api/values/5
        public bool Put(int id, [FromBody]NationalityEntity value)
        {
            if (id > 0)
            {
                return _nationalityServices.UpdateItem(id, value);
            }
            return false;
        }

        // DELETE api/values/5
        public bool Delete(int id)
        {
            if (id > 0)
                return _nationalityServices.DeleteItem(id);
            return false;
        }
    }
}
