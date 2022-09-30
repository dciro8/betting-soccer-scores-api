using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace betting.soccer.scores.api.Domains.UserService.UserPage
{
    public interface IGetSoccerTeam
    {
        Task<IList<SoccerTeam >> GetAllAsync();
    }
}
