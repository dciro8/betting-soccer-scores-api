using AutoMapper;
using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;
using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace betting.soccer.scores.api.Infraestructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // SoccerTeam 
            CreateMap<SoccerTeam, SoccerTeamResponse>();

            // SoccerTeam
            CreateMap<SoccerTeamResponse, SoccerTeam>();

            CreateMap<SoccerGame, SoccerGameResponse>();
            CreateMap<SoccerGameResponse, SoccerGame>();

            // UpdateRequest -> SoccerGame
            CreateMap<SoccerGameResponse, SoccerGame>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                        // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                        return true;
                    }
                ));

        }
    }
}
