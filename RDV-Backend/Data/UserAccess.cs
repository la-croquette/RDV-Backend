﻿using RDV_Backend.Model;
using MySql.Data.MySqlClient;
using Dapper;
using System.Data;


namespace RDV_Backend.Data
{
    public class UserAccess
    {       

        public List<User> GetUsersAll()
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("RDV-Database")))
            {
                return connection.Query<User>("User_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }
        }
        public List<User> GetUserByUsernameAndPassword(string username, string password)
        {
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("RDV-Database")))
            {
                // Define the stored procedure name
                string storedProcedureName = "GetUserByUsernameAndPassword";

                // Create a dynamic parameter object to pass input values to the stored procedure
                var parameters = new
                {
                    inputUsername = username,
                    inputPassword = password
                };

                // Execute the stored procedure and return the result as a list of User objects
                List<User> users = connection.Query<User>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure).ToList();

                return users;
            }
        }

    }
}