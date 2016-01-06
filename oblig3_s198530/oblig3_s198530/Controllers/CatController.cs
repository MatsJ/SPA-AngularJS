using oblig3_s198530.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace oblig3_s198530.Controllers
{
    public class CatController : ApiController
    {
        FAQDB db = new FAQDB();
        public HttpResponseMessage Get()
        {
            List<category> cats = db.getCategories();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(cats);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
