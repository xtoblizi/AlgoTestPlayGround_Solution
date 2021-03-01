using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace TestApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            var result = new ValueReturned { access_token = "Jnoanoidnoidsnnsonosames",
                expiry = 371938,username = "swele@coure-tech.com" };
            var json = new JsonResult(result);

            var client = new RestClient();
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddFile("file", @"C:\Users\COURE-TECH\Pictures\coure_email_picture.jpg");
            request.AddParameter("subject", "Email Delivery now supports File(s) attachment and BCC with  backward compatibility. ");
            request.AddParameter("recipients", "cogbosuka@coure-tech.com");
            request.AddParameter("body", "Testing !! , Now further useful  and handles cases of Blind copy emailing and Multiple or single Files attachment [ANQ Brochure or VHP Brochure] etc email delivery.");
            request.AddParameter("from", "support@coure-tech.com");
            request.AddParameter("bcc", "ogbosukachris@gmail.com");
            request.AddParameter("cc", "ogbosukachrisbiz@gmail.com");

            client.BaseUrl = new Uri("http://localhost:5000/api/message/emailwithattachment");
            IRestResponse response = client.Execute(request);

            return json;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]

        public IActionResult Post([FromBody] dynamic value)
        {
            var result = new ValueReturned
            {
                access_token = "Jnoanoidnoidsnnsonosames",
                expiry = 371938,
                username = "swele@coure-tech.com"
            };
            var json = new JsonResult(result);
            return json;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class ValueReturned
    {
        public string access_token { get; set; }
        public double expiry { get; set; }
        public string  username { get; set; }
    }
}
