using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;
using betting.soccer.scores.api.Domains.UserService.UserPage;
using Microsoft.AspNetCore.Mvc;

namespace betting.soccer.scores.api.Adapters.CountryService
{
    //[Authorize]
    //TODO: Crear autorización
    [Route("[controller]")]
    [ApiController]
    public class SoccerGameController : ControllerBase
    {
        private readonly SoccerTeamProcessor _soccerTeamProcessor;

        public SoccerGameController(SoccerTeamProcessor soccerTeamProcessor)
        {
            _soccerTeamProcessor = soccerTeamProcessor ?? throw new ArgumentNullException(nameof(soccerTeamProcessor));
        }

        /// <summary>
        /// Permite obtener el listado de los equipos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<SoccerGameRegisterResponse>>> GetAllSoccerGameAsync()
        {
            var soccerGames = await _soccerTeamProcessor.GetAllSoccerGameAsync();
            return Ok(soccerGames);
        }

        //TODO: Hacer Get para recuperar Partidos

        [HttpPost()]
        public async Task<ActionResult<SoccerTeamStateResponse>> RegisterSoccerGameAsync(SoccerGameRegisterResponse model)
        {
            var response = await _soccerTeamProcessor.RegisterSoccerGameAsync(model);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SoccerTeamStateResponse>> UpdateSoccerGameAsync(Guid id, SoccerGameRegisterResponse model)
        {
            var response = await _soccerTeamProcessor.UpdateAsync(id, model);
            return Ok(response);
        }

        [HttpDelete()]
        public async Task<ActionResult<SoccerTeamStateResponse>> DeleteSoccerGameAsync(Guid id)
        {
            var response = await _soccerTeamProcessor.DeleteSoccerGameAsync(id);
            return Ok(response);
        }
    }
}
