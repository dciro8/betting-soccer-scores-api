using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace bettingsoccerscoresapi.Domains.UserService.AuthorizationEntity
{
    public interface IGetAuthorizeUser
    {
        Task<SoccerTeam> GetByIdAsync(Guid id);
    }
}
