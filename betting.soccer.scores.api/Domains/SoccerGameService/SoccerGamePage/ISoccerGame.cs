using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public interface ISoccerGame
    {
        Task<int> RemoveSoccerGameAsync(SoccerGame soccerGame);
        Task<int> UpdateAsync(SoccerGame soccerGame);
        Task<SoccerGame> GetByIdSoccerGameAsync(Guid id);
        Task<IList<SoccerGame>> GetAllSoccerGameAsync();
        Task<IList<SoccerGame>> GetListByIdSoccerGameAAsync(Guid team);
        Task<IList<SoccerGame>> GetListByIdSoccerGameBAsync(Guid team);
    }
}
