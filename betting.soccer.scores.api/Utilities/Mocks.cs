using betting.soccer.scores.api.Infraestructure;
using betting.soccer.scores.api.Mediators.UserService.UserPage;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Microsoft.EntityFrameworkCore;

namespace betting.soccer.scores.api.Utilities
{
    public class Mocks
    {
        public void MockPreloadedInformation(DataContext dataContext) {
            
            SoccerTeamMediator soccerTeamMediator = new SoccerTeamMediator(dataContext);

            SoccerTeam soccerTeamRegisterRequest = new SoccerTeam();
            soccerTeamRegisterRequest.TeamName = "Uruguay";
            soccerTeamRegisterRequest.TeamCode = "URU";
            soccerTeamRegisterRequest.Id = Guid.NewGuid();

            soccerTeamMediator.RegisterSoccerTeamAsync(soccerTeamRegisterRequest);
        }

    }
}
