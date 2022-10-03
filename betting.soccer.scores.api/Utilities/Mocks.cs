using betting.soccer.scores.api.Infraestructure;
using betting.soccer.scores.api.Mediators.UserService.UserPage;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace betting.soccer.scores.api.Utilities
{
    public class Mocks
    {
        public void MockPreloadedInformation(DataContext dataContext) {

            SoccerTeam soccerTeamRegisterRequest = new SoccerTeam();
            soccerTeamRegisterRequest.TeamName = "Uruguay1";
            soccerTeamRegisterRequest.TeamCode = "URU";
            soccerTeamRegisterRequest. Id = Guid.NewGuid();
            SoccerTeamMediator soccerTeamMediator = new SoccerTeamMediator(dataContext);
            soccerTeamMediator.RegisterSoccerTeamAsync(soccerTeamRegisterRequest);

        }

    }
}
