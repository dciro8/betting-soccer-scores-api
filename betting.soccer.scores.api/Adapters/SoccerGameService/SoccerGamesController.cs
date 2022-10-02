using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace betting.soccer.scores.api.Adapters.SoccerGameService
{
    [ApiController]
    [Route("[controller]")]
    public class SoccerGamesController : ControllerBase
    {
        private readonly SoccerGameProcessor _soccerGameProcessor;

        public SoccerGamesController(SoccerGameProcessor soccerGameProcessor)
        {
            _soccerGameProcessor = soccerGameProcessor ?? throw new ArgumentNullException(nameof(soccerGameProcessor));
        }

        // GET: SoccerGamesController
        /// <summary>
        /// Permite obtener el listado de los equipos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IList<SoccerGameResponse>>> GetAllSoccerGameAsync()
        {
            //var soccerGames = await _soccerGameProcessor.GetAllSoccerGameAsync();
            //return Ok(soccerGames);
            return Ok();
        }
    }
}
