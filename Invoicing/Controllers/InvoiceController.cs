using Entities.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Invoicing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService _invoicingService;

        public InvoiceController(IInvoiceService invoicingService)
        {
            _invoicingService = invoicingService;
        }

        [HttpPost]
        public IActionResult CreateNewInvoice(NewInvoice invoice)
        {
            return Ok(_invoicingService.InsertNewInvoice(invoice));
        }

        [HttpGet, Route("invoiceDetailLines/{invoiceId}")]
        public IActionResult GetInvoiceDetailLines(int invoiceId)
        {
            return Ok(_invoicingService.GetInvoiceDetailLines(invoiceId));
        }
    }
}
