using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RDV_Backend.Data;
using RDV_Backend.Model;

namespace RDV_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        [HttpPost]
        public JsonResult AddAppointment(Appointment appointment)
        {
            // 添加 CORS 头部
            //Response.Headers.Add("Access-Control-Allow-Origin", "*");

            AppointmentAccess appointmentAccess = new AppointmentAccess();

            try
            {
                // 调用 AddAppointment 方法来添加约会
                appointmentAccess.AddAppointment(appointment);
                return new JsonResult(new { success = true, message = "Appointment added successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Failed to add appointment: " + ex.Message });
            }
        }
        [HttpGet]
        public JsonResult GetAllAppointments()
        {
            // 添加 CORS 头部
            // Response.Headers.Add("Access-Control-Allow-Origin", "*");

            AppointmentAccess appointmentAccess = new AppointmentAccess();

            try
            {
                // 调用 GetAllAppointments 方法来获取所有约会记录
                List<Appointment> appointments = appointmentAccess.GetAllAppointments();
                return new JsonResult(new { success = true, appointments });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Failed to get appointments: " + ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public JsonResult DeleteAppointment(int id)
        {
            AppointmentAccess appointmentAccess = new AppointmentAccess();

            try
            {
                // 调用 DeleteAppointment 方法来删除约会
                appointmentAccess.DeleteAppointment(id);
                return new JsonResult(new { success = true, message = "Appointment deleted successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Failed to delete appointment: " + ex.Message });
            }
        }
        [HttpPut("{id}")]
        public JsonResult UpdateAppointment(int id, Appointment updatedAppointment)
        {
            AppointmentAccess appointmentAccess = new AppointmentAccess();

            try
            {
                // 调用 UpdateAppointment 方法来更新约会
                appointmentAccess.UpdateAppointment(id, updatedAppointment);
                return new JsonResult(new { success = true, message = "Appointment updated successfully" });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = "Failed to update appointment: " + ex.Message });
            }
        }


    }
}
