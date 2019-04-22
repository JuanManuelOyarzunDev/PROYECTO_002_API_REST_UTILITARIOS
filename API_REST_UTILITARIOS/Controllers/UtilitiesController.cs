using API_REST_UTILITARIOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace API_REST_UTILITARIOS.Controllers
{
    public class UtilitiesController : ApiController
    {
        // GET: api/Utilities
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Utilities/5
        [Route("api/Utilities/Email/Send")]
        [HttpPost]
        public async Task<EmailModel> Send()
        {
            string id = string.Empty;
            string message = string.Empty;

            EmailModel resultado_operacion = new EmailModel(id,message);

            resultado_operacion.Id = "1";
            resultado_operacion.Message = "PRUEBA DE CAMBIOS 10.00000001";

            return resultado_operacion;
        }

        // POST: api/Utilities
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Utilities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Utilities/5
        public void Delete(int id)
        {
        }
    }
}
