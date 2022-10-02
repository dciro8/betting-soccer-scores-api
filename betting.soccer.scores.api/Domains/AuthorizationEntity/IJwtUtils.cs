using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace betting.soccer.scores.api.Domains.UserService.AuthorizationEntity
{
    public interface IJwtUtils
    {
        public string GenerateToken(SoccerTeam  user);
        public Guid? ValidateToken(string token);
    }
}
