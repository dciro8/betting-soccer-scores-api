using bettingsoccerscoresapi.Domains.SoccerTeamService.SoccerTeamPage;
using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage
{
    public interface IGetAuthorizeSoccerGame
    {
        Task<SoccerGame> GetByIdSoccerGameAsync(Guid id);
        Task<SoccerTeam> GetByIdSoccerTeamAsync(Guid id);
        Task<int> UpdateAsync(SoccerGame soccerGame);
        Task<int> RemoveSoccerGameAsync(SoccerGame soccerGame);
        Task<int> RemoveSoccerTeamAsync(SoccerTeam soccerGame);
    }
}
