using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ReadJwtTokenDetails.Controllers
{
    public class EmailMessage
    {
        public virtual string MessageType { get; set; }

        public long Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipients { get; set; }
        public string ReplyTo { get; set; }
        public string From { get; set; }
        public string Bcc { get; set; }
        public string Cc { get; set; }
        public long QueuedJobId { get; set; }
        public List<string> AttachmentFilesPath { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            try
            {

                var user = new Users();
                Users.ReturnUsers(10);

                var users = BaseUsers.Users.Take(5);

               // var logins = Users.ReturnUsersLogins(users.ToList());
                
                //var email = new EmailMessage
                //{
                //    Subject = "Updating DS File Attactment ",
                //    Body = "Testing BCC Feature and Update File Attachment",
                //    Recipients = "cogbosuka@coure-tech.com",
                //    From = "support@coure-tech.com",
                //    Cc = "aebube@coure-tech.com",
                //    Bcc = "ogbosukachris@gmail.com"
                //};

                //var uri = $"http://localhost:5000/api/message/emailwithattachment";
                //var multipartContent = new MultipartFormDataContent();

                //using (FileStream fileStream = new FileStream(@"C:\Users\COURE-TECH\Documents\Mail Error Msg.txt", FileMode.Open))
                //{
                //    multipartContent.Add(new StreamContent(fileStream), "\"file\"", @"Mail Error Msg.txt");
                //}

                //string stringified = JsonConvert.SerializeObject(email);

                //var stringContent = new StringContent(stringified);

                //// Email Model other fields
                //multipartContent.Add(stringContent);

                //var httpClient = new HttpClient();
                //var httpResponseMessage = httpClient.PostAsync(uri, multipartContent).Result;

                return new string[] { "value1", "value2" };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [Produces(typeof(JsonResult))]
        [Consumes("application/x-www-form-urlencoded")]
        public  async Task<IActionResult> Post([FromForm] string username, [FromForm] string password,[FromForm] string grant_type)
        {
            try
            {
                if(username.Length > 0 && password.Length > 1)
                {
                    var loginDetails = new LoginDetails()
                    {
                        access_token = "nq;nofiqnoineqoinqoinoeqinoien",
                        token_type = "bearer",
                        expires_in = 1799
                    };
                    var json = new JsonResult(loginDetails);
                    return Ok(loginDetails);
                }
                return BadRequest("Invalid Credentials");
            }
            catch (Exception ex)
            {
                return BadRequest($"Invalid Request, Exception Caught /n {ex}");
            }
            
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = Request.Headers["Authorization"];
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            var nameId = tokenS.Claims.First(claim => claim.Type == "nameid").Value;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        
    }

    public class LoginDetails
    {
        public int Id { get; set; }
        public string access_token { get; set; }
        public string token_type { get; set; }
        public double expires_in { get; set; }
    }

    public class UserLogin : BaseUsers
    { 
        public UserLogin()
        {
            DateOfLogin = DateTime.UtcNow;
            Reference = Guid.NewGuid().ToString().Substring(0,6);
        }

        public string Reference { get; set; }
        public DateTime DateOfLogin { get; set; }
        public string Username { get; set; }

        public string LoginKeyGeneration { get; set; }

    }

    public class BaseUsers
    {
        public static IEnumerable<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
        public static IEnumerable<Users> Users { get; set; } = new List<Users>();
    }
    public class Users : BaseUsers
    { 
        public Users()
        {
            DateCreated = DateTime.UtcNow;   
        }
        public int Id { get; set; }
        public string Username { get; set; }

        public string Location { get; set; }
        public DateTime DateCreated { get; set; }

        public static IEnumerable<Users> ReturnUsers(int countofuserstoresturn = 10)
        {
            List<Users> users = new List<Users>();
            List<UserLogin> userlogins = new List<UserLogin>();

            for (int i = 0; i < countofuserstoresturn; i++)
            {
                var user = new Users
                {
                    Id = i,
                    Username = $"Xto{i}",
                    Location = $"Location{new Guid().ToString().Substring(0,4)}",
                };
                users.Add(user);
            }

            foreach (var item in users)
            {
                var userlogin = new UserLogin
                {
                    Username = item.Username,
                    LoginKeyGeneration = "1"
                };

                var userlogin2 = new UserLogin
                {
                    Username = item.Username,
                    LoginKeyGeneration = "1"
                };
                var userlogin3 = new UserLogin
                {
                    Username = item.Username,
                    LoginKeyGeneration ="2",
                };

                userlogins.Add(userlogin);
                userlogins.Add(userlogin2);
                userlogins.Add(userlogin3);
            }

            BaseUsers.UserLogins = userlogins;
            BaseUsers.Users = users;
            return users;
        }

        public static IEnumerable<UserLogin> ReturnUsersLogins(List<Users> users)
        {
            //Func<List<Users>, bool> func = (x => x.Any(y => y.Username == users.))
            //foreach (var item in users)
            //{

            //}

            //var result = UserLogins.Where(expressionroute);

            return null;
        }
        public static IEnumerable<UserLogin> ReturnUsersLogins(List<UserLogin> userLogins)
        {

            //Func<UserLogin, bool> expressionroute = (x => UserLogin.Any(p => x.LoginKeyGeneration));

            //var result = UserLogins.Where(expressionroute);

            return null ;
        }        
    }
}
