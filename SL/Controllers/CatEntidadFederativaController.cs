using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class CatEntidadFederativaController : ApiController
    {
        // GET: api/CatEntidadFederativa
        [HttpGet]
        [Route("api/CatEntidadFederativa/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.CatEntidadFederativa.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/CatEntidadFederativa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CatEntidadFederativa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CatEntidadFederativa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CatEntidadFederativa/5
        public void Delete(int id)
        {
        }
    }
}
