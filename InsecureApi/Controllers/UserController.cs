using InsecureApi.Classes;
using InsecureApi.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace InsecureApi.Controllers
{
    [ApiController]
    [Route("insecureApi/[controller]")]
    public class UserController : ControllerBase
    {
        private DatabaseOperations db;

        public UserController()
        {
            db = new DatabaseOperations();
        }

        [HttpGet]
        [Route("account/{userId}")]
        public IActionResult GetAccount([FromRoute] string userId)
        {
            List<User> list = db.GetAccount(userId);
            return new JsonResult(list);
        }

        [HttpPost]
        [Route("login")]
        public bool GetAccount([FromBody] UserLogin request)
        {
            string user = request.name;
            string password = request.password;

            return db.Login(user, password);
        }

        [HttpGet]
        [Route("parameterized/{userId}")]
        public IActionResult GetParameterizedAccount([FromRoute] string userId)
        {
            List<User> list = db.GetParameterizedAccount(userId);
            return new JsonResult(list);
        }

        [HttpPost]
        [Route("changePassword")]
        public IActionResult ChangePassword([FromBody] ChangePassword request)
        {
            string id = request.id;
            string newPassword = request.password;

            db.ChangePassword(id, newPassword);

            return new JsonResult(true);
        }
    }
}