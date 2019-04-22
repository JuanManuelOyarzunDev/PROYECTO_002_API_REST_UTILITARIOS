using API_REST_UTILITARIOS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace API_REST_UTILITARIOS.Controllers
{
    public class UtilitiesController : ApiController
    {

        // GET: api/Utilities/Email/Send
        [Route("api/Utilities/Email/Send")]
        [HttpPost]
        public IHttpActionResult Send(string from, string to, string subject, string text = null, string html = null)
        {
            var client = new HttpClient();
            EmailModel resultado_operacion;

            try
            {
                string domain = System.Configuration.ConfigurationManager.AppSettings["Domain"];
                string apiKey = System.Configuration.ConfigurationManager.AppSettings["ApiKey"];
                string keyBase64 = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes("api" + ":" + apiKey));

                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", keyBase64);
                string servicio = string.Format("https://api.mailgun.net/v2/{0}/messages", domain);

                var form = new Dictionary<string, string>();
                form["from"] = from;
                form["to"] = to;
                form["subject"] = subject;
                form["text"] = text;
                form["html"] = html;


                var data = new FormUrlEncodedContent(form);

                var response = client.PostAsync(servicio, data);
                if (response.Result.StatusCode == HttpStatusCode.OK)
                {
                    var content = response.Result.Content.ReadAsStringAsync().Result;
                    resultado_operacion = JsonConvert.DeserializeObject<EmailModel>(content);
                }
                else
                {
                    if (response.Result.StatusCode == HttpStatusCode.NoContent)
                    {
                        return StatusCode(HttpStatusCode.NoContent);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            finally
            {
                client.Dispose();
            }

            return Ok(resultado_operacion);
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
