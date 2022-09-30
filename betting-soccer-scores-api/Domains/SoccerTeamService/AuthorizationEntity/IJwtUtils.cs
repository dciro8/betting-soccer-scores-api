using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace Transenvios.Shipping.Api.Domains.UserService.AuthorizationEntity
{
    public interface IJwtUtils
    {
        public string GenerateToken(SoccerTeam  user);
        public Guid? ValidateToken(string token);
    }
}
