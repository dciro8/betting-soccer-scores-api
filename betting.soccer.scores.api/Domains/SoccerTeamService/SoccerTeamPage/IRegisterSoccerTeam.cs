using bettingsoccerscoresapi.Domains.SoccerTeamService.SoccerTeamPage;

namespace bettingsoccerscoresapi.Domains.UserService.UserPage
{
    public interface IRegisterSoccerTeam
    {
        Task<int> RegisterSoccerTeamAsync(SoccerTeam  data);
        Task<int> RegisterSoccerGameAsync(SoccerGame data);
    }
}
