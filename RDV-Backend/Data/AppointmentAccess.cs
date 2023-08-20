using System;
using RDV_Backend.Model;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace RDV_Backend.Data
{
    public class AppointmentAccess
    {
        public void AddAppointment(Appointment appointment)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("RDV-Database")))
            {
                string storedProcedureName = "Appointment_Add";

                var parameters = new
                {
                    userId = appointment.User_Id,
                    clientName = appointment.Client_Name,
                    appointmentDateTime = appointment.Appointment_Date,
                    appointmentSubject = appointment.Appointment_Subject
                };

                connection.Query(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public List<Appointment> GetAllAppointments()
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("RDV-Database")))
            {
                string storedProcedureName = "Appointments_GetAll"; // Replace with your stored procedure name

                return connection.Query<Appointment>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();
            }
        }
    }

}