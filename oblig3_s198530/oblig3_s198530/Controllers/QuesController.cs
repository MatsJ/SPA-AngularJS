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
    public class QuesController : ApiController
    {
        FAQDB db = new FAQDB();
        public HttpResponseMessage Get()
        {
            List<question> unanswered = db.listNewQuestions();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(unanswered);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
