using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Transenvios.Shipping.Api.Adapters.UserService.AuthorizationEntity;
using Transenvios.Shipping.Api.Domains.UserService.UserPage;
using Transenvios.Shipping.Api.Infraestructure;

namespace Transenvios.Shipping.Api.Adapters.UserService.UserPage
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly AppSettings _appSettings;
        private readonly UserProcessor _userProcessor;
        
        public UsersController(
            ILogger<UsersController> logger,
            IOptions<AppSettings> appSettings,
            UserProcessor userProcessor
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userProcessor = userProcessor ?? throw new ArgumentNullException(nameof(userProcessor));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync()
        {
            
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost()]
        public async Task<ActionResult<UserStateResponse>> RegisterAsync()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("ForgotPassword")]
        public async Task<ActionResult<UserStateResponse>> ForgotPassword()
        {            
            return Ok();
        }
    }
}