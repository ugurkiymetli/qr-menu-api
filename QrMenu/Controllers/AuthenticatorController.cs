using Microsoft.AspNetCore.Mvc;
using QrMenu.Services;
using QrMenu.ViewModels;

namespace QrMenu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {
        private readonly IAuthenticatorService authenticatorService;
        public AuthenticatorController(IAuthenticatorService authenticatorService)
        {
            this.authenticatorService = authenticatorService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var result = await authenticatorService.Login(model.Username, model.Password);

            if (result is null)
                return BadRequest("Invalid credentials");
            else
                return Ok(result);
        }
    }
}

