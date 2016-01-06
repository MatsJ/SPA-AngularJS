using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Net.Http.Formatting;
using System.Data.Common;
using oblig3_s198530;
using oblig3_s198530.Models;


namespace oblig3_s198530
{
    public class FaqController : ApiController
    {
        FAQDB db = new FAQDB();

        // GET api/Faq
        public HttpResponseMessage Get()
        {
            List<FAQ> allFAQ = db.getAllFAQ();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(allFAQ);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }

        
        // GET api/Faq/
        public HttpResponseMessage GetFAQ(int categoryid)
        {
            List<FAQ> categoryfaq = db.getFAQCategory(categoryid);

            var Json = new JavaScriptSerializer();
            String JsonString = Json.Serialize(categoryfaq);

            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json")
            };
        }
        

        // POST api/Faq
        public HttpResponseMessage Post(question faq)
        {
                bool OK = db.addFAQ(faq);
                if (OK)
                {
                    return new HttpResponseMessage()
                    {
                        StatusCode = HttpStatusCode.OK
                    };

                }
            
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound,
                Content = new StringContent("Kunne ikke sette inn spørsmålet i DB")
            };
        }

        

        /*
        //GET api/FAQ
        public HttpResponseMessage newQuestions()
        {
            List<FAQ> unanswered = db.listNewQuestions();

            var Json = new JavaScriptSerializer();
            string JsonString = Json.Serialize(unanswered);

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonString, Encoding.UTF8, "application/json"),
                StatusCode = HttpStatusCode.OK
            };
        }
        */
    }
}
