using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage
{
    public interface ISoccerTeam
    {        
        Task<SoccerTeam> GetByIdSoccerTeamAsync(Guid id);        
        Task<int> RemoveSoccerTeamAsync(SoccerTeam soccerGame);
        Task<IList<SoccerTeam>> GetAllSoccerTeamAsync();
    }
}
