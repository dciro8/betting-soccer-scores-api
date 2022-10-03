using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;

namespace betting.soccer.scores.api.Domains.UserService.AuthorizationEntity
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ISoccerTeam userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")?.Last();
            var soccerTeamId = jwtUtils.ValidateToken(token);
            if (soccerTeamId != null)
            {
                //TODO: Ver tarea
                // attach user to context on successful jwt validation
                context.Items["User"] = userService.GetByIdSoccerTeamAsync(soccerTeamId.Value);
            }

            await _next(context);
        }
    }
}
