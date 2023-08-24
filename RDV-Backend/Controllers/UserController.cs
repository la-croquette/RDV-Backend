using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RDV_Backend.Data;
using RDV_Backend.Model;
using System.Collections.Generic;

namespace RDV_Backend.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [HttpPost]
        public JsonResult Login(User user)
        {
            // 添加 CORS 头部
            //Response.Headers.Add("Access-Control-Allow-Origin", "*");

            UserAccess userAccess = new UserAccess();
            List<User> users = userAccess.GetUserByUsernameAndPassword(user.Username ?? "", user.Password ?? "");

            if (users.Count == 0)
            {
                return new JsonResult(new { success = false, message = "Login failed: Name and password do not match" });
            }

            User loggedInUser = users[0];
            return new JsonResult(new { success = true, message = "Login successful", user = loggedInUser });
        }

        [HttpGet]
        public JsonResult GetAllUsers()
        {
            // 添加 CORS 头部
            //Response.Headers.Add("Access-Control-Allow-Origin", "*");

            UserAccess userAccess = new UserAccess();
            List<User> allUsers = userAccess.GetUsersAll();

            return new JsonResult(new { success = true, users = allUsers });
        }
    }
}
