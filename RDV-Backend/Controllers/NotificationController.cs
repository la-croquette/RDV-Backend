using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDV_Backend.Data;

namespace RDV_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {

        [HttpPost("AddNotification")]
        public JsonResult AddNotification(int user_Id, string message)
        {
            try
            {
                NotificationAccess notificationAccess = new NotificationAccess();
                notificationAccess.AddNotification(user_Id, message);

                return new JsonResult(new { success = true, message = "Notification added successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "An error occurred", error = ex.Message });
            }
        }
    }
}
