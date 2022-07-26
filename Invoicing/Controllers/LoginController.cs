using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Invoicing.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet, Route("ValidateLogin/{username}/{password}")]
        public IActionResult ValidateLogin(string username, string password)
        {
            return Ok(_loginService.ValidateUser(username, password));
        }
    }
}
