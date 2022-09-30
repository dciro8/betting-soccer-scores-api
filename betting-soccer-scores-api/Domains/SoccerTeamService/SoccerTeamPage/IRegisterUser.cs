namespace bettingsoccerscoresapi.Domains.UserService.UserPage
{
    public interface IRegisterUser
    {
        Task<int> RegisterAsync(SoccerTeam  data);
    }
}
