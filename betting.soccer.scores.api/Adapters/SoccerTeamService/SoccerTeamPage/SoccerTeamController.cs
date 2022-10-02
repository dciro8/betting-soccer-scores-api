using betting.soccer.scores.api.Domains.Generic;
using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;
using betting.soccer.scores.api.Domains.UserService.UserPage;
using Microsoft.AspNetCore.Mvc;

namespace betting.soccer.scores.api.Adapters.UserService.UserPage
{
    /// <summary>
    /// Controlador encargado de administrar los equipos
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SoccerTeamController : ControllerBase
    {
        private readonly SoccerTeamProcessor _soccerTeamProcessor;
        
        public SoccerTeamController(SoccerTeamProcessor soccerTeamProcessor)
        {
            _soccerTeamProcessor = soccerTeamProcessor ?? throw new ArgumentNullException(nameof(soccerTeamProcessor));
        }
        //TODO: Separar carpertas de Soocer Team de Soccer Game

        /// <summary>
        /// Permite obtener el listado de los equipos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<SoccerGameResponse>>> GetAllSoccerGameAsync()
        {
            var soccerTeams = await _soccerTeamProcessor.GetAllSoccerGameAsync();
            return Ok(soccerTeams);
        }
        
        [HttpPost()]
        public async Task<ActionResult<SoccerTeamStateResponse>> RegisterSoccerTeamAsync(SoccerTeamResponse model)
        {
            var response = await _soccerTeamProcessor.RegisterSoccerTeamAsync(model);
            return Ok(response);
        }

        [HttpDelete()]
        public async Task<ActionResult<SoccerTeamStateResponse>> DeleteSoccerTeamAsync(Guid id)
        {
            var response = await _soccerTeamProcessor.DeleteSoccerTeamAsync(id);
            return Ok(response);
        }
    }
}