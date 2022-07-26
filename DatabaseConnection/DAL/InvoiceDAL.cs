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
    public class InvoiceDAL : IInvoiceDAL
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private const string ConnectionString = "Default";
        private const string InsertInvoiceSP = "InsertInvoice";
        private const string InsertInvoiceDetailLineSP = "InsertInvoiceDetailLine";
        private const string GetInvoiceDetailLinesSP = "GetInvoiceDetailLines";

        public InvoiceDAL(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(ConnectionString);
        }

        public bool InsertInvoice(NewInvoice invoice)
        {
            bool success = true;

            try
            {
                using SqlConnection con = new SqlConnection(_connectionString);
                {
                    SqlCommand cmd = new SqlCommand(InsertInvoiceSP, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.Add("@InvoiceNumber", SqlDbType.VarChar).Value = invoice.InvoiceNumber;
                    cmd.Parameters.Add("@Date", SqlDbType.Date).Value = invoice.Date;
                    cmd.Parameters.Add("@VendorId", SqlDbType.Int).Value = invoice.VendorId;
                    cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = invoice.ClientId;

                    int result = (int)cmd.ExecuteScalar();

                    foreach (var detail in invoice.DetailLines)
                    {
                        cmd = new SqlCommand(InsertInvoiceDetailLineSP, con);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@Description", SqlDbType.VarChar).Value = detail.Description;
                        cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = detail.Amount;
                        cmd.Parameters.Add("@Price", SqlDbType.Float).Value = detail.Price;
                        cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = result;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
        }

        public List<DetailLine> GetInvoiceDetailLines(int invoiceId)
        {
            var detailLines = new List<DetailLine>();

            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(GetInvoiceDetailLinesSP, con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.Add("@InvoiceId", SqlDbType.Int).Value = invoiceId;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        detailLines.Add(new DetailLine
                        {
                            Id = reader.GetInt32("Id"),
                            Description = reader.GetString("Description"),
                            Amount = reader.GetDouble("Amount"),
                            Price = reader.GetDouble("Price")
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return detailLines;
        }
    }
}
