using API.Services;
using Azure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IClientAuthenticationService _clientAuthenticationService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IClientAuthenticationService clientAuthenticationService, ILogger<AuthController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _clientAuthenticationService = clientAuthenticationService ?? throw new ArgumentNullException(nameof(clientAuthenticationService));
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Get([FromQuery] string clientId, [FromQuery] string clientSecret)
        {
            try
            {
                var token = _clientAuthenticationService.Authenticate(clientId, clientSecret);
                return Ok(new { token });
            }
            catch (AuthenticationFailedException ex)
            {
                return this.Unauthorized(ex.Message);
            }
        }
    }
}
