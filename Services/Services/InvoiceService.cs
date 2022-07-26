using DatabaseConnection.Interfaces;
using Entities;
using Entities.Model;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceDAL _invoiceDAL;

        public InvoiceService(IInvoiceDAL invoiceDAL)
        {
            _invoiceDAL = invoiceDAL;
        }

        public bool InsertNewInvoice(NewInvoice invoice)
        {
            return _invoiceDAL.InsertInvoice(invoice);
        }

        public List<DetailLine> GetInvoiceDetailLines(int invoiceId)
        {
            return _invoiceDAL.GetInvoiceDetailLines(invoiceId);
        }
    }
}
