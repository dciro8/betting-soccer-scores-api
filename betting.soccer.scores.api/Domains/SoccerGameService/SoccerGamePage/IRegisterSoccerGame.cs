using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;

namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public interface IRegisterSoccerGame
    {
        Task<int> RegisterSoccerGameAsync(SoccerGame data);
    }
}
