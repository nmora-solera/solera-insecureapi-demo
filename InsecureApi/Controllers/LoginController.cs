using InsecureApi.Classes;
using InsecureApi.Database;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace InsecureApi.Controllers
{
    [ApiController]
    [Route("insecureApi/[controller]")]
    public class LoginController : ControllerBase
    {
        private DatabaseOperations db;

        private List<string> locationWhitelist = new List<string>()
        {
            "127.0.0.1:5000/insecureApi/Dashboard.aspx",
            "127.0.0.1:5000/insecureApi/Controls.aspx",
            "127.0.0.1:5000/insecureApi/Admin.aspx"
        };

        public LoginController()
        {
            db = new DatabaseOperations();
        }

        [HttpPost]
        [Route("insecureLogin")]
        public IActionResult insecureValidateLogin(
            [FromQuery] string redirectLocation,
            [FromBody] UserLogin userInfo)
        {
            if (!db.Login(userInfo.name, userInfo.password))
            {
                return new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Content = "Invalid credentials",
                    ContentType = "text/plain"
                };
            }

            SessionManager.user.name = userInfo.name;

            return Redirect(redirectLocation);
        }

        [HttpPost]
        [Route("secureLogin")]
        public IActionResult secureLogin(
            [FromQuery] string redirectLocation, 
            [FromBody] UserLogin userInfo)
        {
            if (!db.Login(userInfo.name, userInfo.password))
            {
                return new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Content = "Invalid credentials",
                    ContentType = "text/plain"
                };
            }

            if (!locationWhitelist.Any(l => l.Equals(redirectLocation)))
            {
                return new ContentResult
                {
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Content = "Path does not exist in the server",
                    ContentType = "text/plain"
                };
            }

            SessionManager.user.name = userInfo.name;

            return Redirect(redirectLocation);
        }
    }
}