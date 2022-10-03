using betting.soccer.scores.api.Domains.Generic;
using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using betting.soccer.scores.api.Domains.UserService.UserPage;
using Microsoft.AspNetCore.Mvc;
          
namespace betting.soccer.scores.api.Adapters.SoccerGameService
{
    //[Authorize]
    //TODO: Crear autorización
    
    [ApiController]
    [Route("[controller]")]
    public class SoccerGameController : ControllerBase
    {
        private readonly SoccerGameProcessor _soccerGameProcessor;

        public SoccerGameController(SoccerGameProcessor soccerGameProcessor)
        {
            _soccerGameProcessor = soccerGameProcessor ?? throw new ArgumentNullException(nameof(soccerGameProcessor));
        }

        /// <summary>
        /// Permite obtener el listado de los equipos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<SoccerGameResponse>>> GetAllSoccerGameAsync()
        {
            var soccerGames = await _soccerGameProcessor.GetAllSoccerGameAsync();
            return Ok(soccerGames);
        }

        //TODO: Hacer Get para recuperar Partidos

        [HttpPost()]
        public async Task<ActionResult<SoccerTeamStateResponse>> RegisterSoccerGameAsync(SoccerGameResponse model)
        {
            var response = await _soccerGameProcessor.RegisterSoccerGameAsync(model);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SoccerTeamStateResponse>> UpdateSoccerGameAsync(Guid id, SoccerGameResponse model)
        {
            var response = await _soccerGameProcessor.UpdateAsync(id, model);
            return Ok(response);
        }

        [HttpDelete()]
        public async Task<ActionResult<SoccerTeamStateResponse>> DeleteSoccerGameAsync(Guid id)
        {
            var response = await _soccerGameProcessor.DeleteSoccerGameAsync(id);
            return Ok(response);
        }
    }
}
