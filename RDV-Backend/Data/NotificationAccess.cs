using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using RDV_Backend.Model;

namespace RDV_Backend.Data
{
	public class NotificationAccess
	{
        public void AddNotification(int user_Id, string message)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("RDV-Database")))
            {
                string storedProcedureName = "Notification_Add";

                var parameters = new
                {
                    user_Id = user_Id,
                    Message = message
                };

                connection.Query(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
        public List<Notification> GetNotificationsByUserId(int user_Id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("RDV-Database")))
            {
                string storedProcedureName = "Notification_GetByUserId";

                var parameters = new
                {
                    user_Id = user_Id
                };

                return connection.Query<Notification>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public void DeleteNotificationsByUserId(int user_Id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("RDV-Database")))
            {
                string storedProcedureName = "Notification_DeleteByUserId";

                var parameters = new
                {
                    user_id = user_Id
                };

                connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

    }
}

