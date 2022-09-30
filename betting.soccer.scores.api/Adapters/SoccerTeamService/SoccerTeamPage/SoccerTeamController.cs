using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using betting.soccer.scores.api.Adapters.UserService.AuthorizationEntity;
using betting.soccer.scores.api.Domains.UserService.UserPage;
using betting.soccer.scores.api.Infraestructure;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;

namespace betting.soccer.scores.api.Adapters.UserService.UserPage
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SoccerTeamController : ControllerBase
    {
        private readonly ILogger<SoccerTeamController> _logger;
        private readonly AppSettings _appSettings;
        private readonly SoccerTeamProcessor _soccerTeamProcessor;
        
        public SoccerTeamController(
            ILogger<SoccerTeamController> logger,
            IOptions<AppSettings> appSettings,
            SoccerTeamProcessor soccerTeamProcessor
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _soccerTeamProcessor = soccerTeamProcessor ?? throw new ArgumentNullException(nameof(soccerTeamProcessor));
            _appSettings = appSettings.Value ?? throw new ArgumentNullException(nameof(appSettings));
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync()
        {
            
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("RegisterSoccerGame")]
        public async Task<ActionResult<SoccerTeamStateResponse>> RegisterSoccerGameAsync(SoccerGameRegisterRequest model)
        {
            var response = await _soccerTeamProcessor.RegisterSoccerGameAsync(model);
            return Ok(response);
        }


        [AllowAnonymous]    
        [HttpPut("{id}")]
        public async Task<ActionResult<SoccerTeamStateResponse>> UpdateAsync(Guid id, SoccerGameRegisterRequest model)
        {
            var response = await _soccerTeamProcessor.UpdateAsync(id, model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("RegisterSoccerTeam")]
        public async Task<ActionResult<SoccerTeamStateResponse>> RegisterSoccerTeamAsync(SoccerTeamRegisterRequest model)
        {
            var response = await _soccerTeamProcessor.RegisterSoccerTeamAsync(model);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("DeleteSoccerGameAsync")]
        public async Task<ActionResult<SoccerTeamStateResponse>> DeleteSoccerGameAsync(Guid id)
        {
            var response = await _soccerTeamProcessor.DeleteSoccerGameAsync(id);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpDelete("DeleteSoccerTeamAsync")]
        public async Task<ActionResult<SoccerTeamStateResponse>> DeleteSoccerTeamAsync(Guid id)
        {
            var response = await _soccerTeamProcessor.DeleteSoccerTeamAsync(id);
            return Ok(response);
        }
    }
}