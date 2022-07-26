using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Invoicing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            return Ok(_clientService.GetAllClients());
        }

        [HttpGet, Route("clientInvoices/{clientId}")]
        public IActionResult GetClientInvoices(int clientId)
        {
            return Ok(_clientService.GetClientInvoices(clientId));
        }
    }
}
