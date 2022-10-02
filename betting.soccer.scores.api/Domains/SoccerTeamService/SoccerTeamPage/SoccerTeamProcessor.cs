using AutoMapper;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using betting.soccer.scores.api.Domains.UserService.AuthorizationEntity;
using betting.soccer.scores.api.Infraestructure;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;
using betting.soccer.scores.api.Domains.Generic;

namespace betting.soccer.scores.api.Domains.UserService.UserPage
{
    public class SoccerTeamProcessor
    {
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        private readonly IRegisterSoccerTeam _registerSoccerTeam;
        private readonly IGetSoccerTeam _getSoccerTeam;
        private readonly ISoccerTeam _getAuthorizeSoccerTeam;

        public SoccerTeamProcessor(
            IMapper mapper,
            IJwtUtils jwtUtils,
            IRegisterSoccerTeam registerSoccerTeam,
            IGetSoccerTeam SoccerTeam,
            ISoccerTeam getAuthorizeTeam
            )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtUtils = jwtUtils ?? throw new ArgumentNullException(nameof(jwtUtils));
            _registerSoccerTeam = registerSoccerTeam ?? throw new ArgumentNullException(nameof(registerSoccerTeam));
            _getSoccerTeam = SoccerTeam ?? throw new ArgumentNullException(nameof(SoccerTeam));
            _getAuthorizeSoccerTeam = getAuthorizeTeam ?? throw new ArgumentNullException(nameof(getAuthorizeTeam));
        }
        public async Task<SoccerTeamStateResponse> RegisterSoccerTeamAsync(SoccerTeamResponse model)
        {
            try
            {
                var soccerTeam = _mapper.Map<SoccerTeam>(model);
                var items = await _registerSoccerTeam.RegisterSoccerTeamAsync(soccerTeam);

                return new SoccerTeamStateResponse
                {
                    Id = soccerTeam.Id,
                    Items = items,
                    Message = "Registration successful"
                };
            }
            catch (Exception ex)
            {
                return new SoccerTeamStateResponse
                {
                    Message = ex.GetBaseException().Message
                };
            }
        }
        public async Task<SoccerTeamStateResponse> DeleteSoccerTeamAsync(Guid id)
        {
            var currentSoccerTeam = await GetSoccerTeamAsync(id);
            var items = await _getAuthorizeSoccerTeam.RemoveSoccerTeamAsync(currentSoccerTeam);

            return new SoccerTeamStateResponse
            {
                Id = currentSoccerTeam.Id,
                Items = items,
                Message = "Soccer Team deleted successfully"
            };
        }    
        private async Task<SoccerTeam> GetSoccerTeamAsync(Guid id)
        {
            var soccerGame = await _getAuthorizeSoccerTeam.GetByIdSoccerTeamAsync(id);
            if (soccerGame == null)
            {
                throw new KeyNotFoundException("Soccer Team not found");
            }
            return soccerGame;
        }
        public async Task<IList<SoccerTeamResponse>> GetAllSoccerGameAsync()
        {
            var response = await _getAuthorizeSoccerTeam.GetAllSoccerTeamAsync();
            var soccerTeam = _mapper.Map<IList<SoccerTeamResponse>>(response);
            return soccerTeam;
        }
    }
}