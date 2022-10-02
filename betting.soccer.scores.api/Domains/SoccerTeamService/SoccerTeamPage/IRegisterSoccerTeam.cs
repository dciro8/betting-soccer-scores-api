
namespace bettingsoccerscoresapi.Domains.UserService.UserPage
{
    public interface IRegisterSoccerTeam
    {
        Task<int> RegisterSoccerTeamAsync(SoccerTeam  data);
     
    }
}
