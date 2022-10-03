using betting.soccer.scores.api.Domains.Generic;
using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace betting.soccer.scores.Tests.Mocks
{
    public class SoccerGameMocks
    {
        public SoccerGameMocks()
        { }

        public static int _indicateError = 500;
        public static SoccerGame SoccerGameMock()
        {
            SoccerGame soccerGame = new SoccerGame();

            soccerGame.TeamAId = "5F0FAF82-EA61-40A7-E1E3-08DAA3B22242";
            soccerGame.TeamBId = "5A001F2A-B545-453A-B531-08DAA4740421";
            soccerGame.DateGame = DateTime.Now;
            soccerGame.Status = EnumStateGame.P.ToString();
            soccerGame.ScoreTeamA = 0;
            soccerGame.ScoreTeamB = 0;

            return soccerGame;
        }


        public static SoccerGameResponse SoccerGameResponse(bool test)
        {
            SoccerGameResponse soccerGameResponse = new SoccerGameResponse();

            if (test)
            soccerGameResponse.TeamAId = "5F0FAF82-EA61-40A7-E1E3-08DAA3B22242";
            else
            soccerGameResponse.TeamAId = "5F0FAF82-EA61-40A7-E1E3-08DAA3B2224";
            soccerGameResponse.TeamBId = "5A001F2A-B545-453A-B531-08DAA4740421";
            soccerGameResponse.DateGame = DateTime.Now;
            soccerGameResponse.Status = EnumStateGame.P.ToString();
            soccerGameResponse.ScoreTeamA = 0;
            soccerGameResponse.ScoreTeamB = 0;

            return soccerGameResponse;
        }

        public static SoccerTeamStateResponse SoccerTeamStateResponse()
        {

            return new SoccerTeamStateResponse
            {
                Id = Guid.NewGuid(),
                Items = 1,
                Message = SoccerGameConstants.Registration
            };
        }
        public static Task<int> returnChangesAsync()
        {
            return Task.FromResult(1);
        }
    }
}
