using Entities;
using Entities.Model;
using System.Collections.Generic;

namespace DatabaseConnection.Interfaces
{
    public interface IInvoiceDAL
    {
        public bool InsertInvoice(NewInvoice invoice);
        public List<DetailLine> GetInvoiceDetailLines(int invoiceId);
    }
}
