using DatabaseConnection.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection.DAL
{
    public class LoginDAL : ILoginDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private const string ConnectionString = "Default";
        private const string ValidateUserSP = "ValidateUser";

        public LoginDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(ConnectionString);
        }

        public bool ValidateUser(string username, string password)
        {
            bool authorized = false;

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(ValidateUserSP, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.Add("@Username", SqlDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = password;

                    int result = (int)cmd.ExecuteScalar();

                    if (result == 1)
                    {
                        authorized = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return authorized;
        }
    }
}
