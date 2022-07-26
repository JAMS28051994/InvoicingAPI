using Entities;
using Entities.Model;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IInvoiceService
    {
        public bool InsertNewInvoice(NewInvoice invoice);
        public List<DetailLine> GetInvoiceDetailLines(int invoiceId);
    }
}
