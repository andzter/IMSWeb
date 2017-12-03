using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IMSWeb.Controllers
{
    public class HelloApiController : ApiController
    {
        // GET: api/HelloApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/HelloApi/5
        /*
        public string Get(int id)
        {
            return "Hello API" + DateTime.Now.ToLongDateString();
        }
        */

        public HttpResponseMessage Get(int id)
        {
            if (id == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Id is zero");
            }
            else
            {
                return Request.CreateResponse<string>(HttpStatusCode.OK, "Hello API " + id.ToString());
            }
        }


        // POST: api/HelloApi
        /*
        public void Post([FromBody]string value)
        {

        }
        */

        // POST: api/HelloApi
        public HttpResponseMessage Post([FromBody]string value)
        {
            var msg = Request.CreateResponse(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + value);
            return msg;
        }

        // PUT: api/HelloApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/HelloApi/5
        public void Delete(int id)
        {
        }
    }
}
