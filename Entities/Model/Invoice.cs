using Entities.Model;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class Invoice
    {
        public Invoice()
        {
            DetailLines = new List<DetailLine>();
        }

        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public List<DetailLine> DetailLines { get; set; }
        public Vendor Vendor { get; set; }
        public Client Client { get; set; }
        public double TotalPrice { get; set; }
    }
}
