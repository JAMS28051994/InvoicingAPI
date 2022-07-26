using DatabaseConnection.Interfaces;
using Entities;
using Entities.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DatabaseConnection.DAL
{
    public class ClientDAL : IClientDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private const string ConnectionString = "Default";
        private const string GetAllClientsSP = "GetAllClients";
        private const string GetClientInvoicesSP = "GetClientInvoices";

        public ClientDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(ConnectionString);
        }

        public List<Client> GetAllClients()
        {
            var clients = new List<Client>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(GetAllClientsSP, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        clients.Add(new Client
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

            return clients;
        }

        public List<Invoice> GetClientInvoices(int clientId)
        {
            var invoices = new List<Invoice>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(GetClientInvoicesSP, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = clientId;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        invoices.Add(new Invoice
                        {
                            Id = reader.GetInt32("Id"),
                            InvoiceNumber = reader.GetString("InvoiceNumber"),
                            Date = reader.GetDateTime("Date"),
                            TotalPrice = reader.GetDouble("TotalPrice"),
                            Vendor = new Vendor
                            {
                                Name = reader.GetString("Name")
                            }
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return invoices;
        }
    }
}
