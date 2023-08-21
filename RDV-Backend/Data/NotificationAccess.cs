using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;

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
    }
}

