using DatabaseConnection.Interfaces;
using Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection.DAL
{
    public class VendorDAL : IVendorDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private const string ConnectionString = "Default";
        private const string GetAllVendorsSP = "GetAllVendors";

        public VendorDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(ConnectionString);
        }

        public List<Vendor> GetAllVendors()
        {
            var vendors = new List<Vendor>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(GetAllVendorsSP, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        vendors.Add(new Vendor
                        {
                            Id = reader.GetInt32("Id"),
                            IDNumber = reader.GetString("IDNumber"),
                            Name = reader.GetString("Name"),
                            PhoneNumber = reader.GetString("PhoneNumber"),
                            Email = reader.GetString("Email")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return vendors;
        }
    }
}
