using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public class NewInvoice
    {
        public NewInvoice()
        {
            DetailLines = new List<DetailLine>();
        }

        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime Date { get; set; }
        public List<DetailLine> DetailLines { get; set; }
        public int VendorId { get; set; }
        public int ClientId { get; set; }
    }
}
