using AutoMapper;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using betting.soccer.scores.api.Domains.UserService.AuthorizationEntity;
using betting.soccer.scores.api.Infraestructure;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;
using bettingsoccerscoresapi.Domains.SoccerTeamService.SoccerTeamPage;

namespace betting.soccer.scores.api.Domains.UserService.UserPage
{
    public class SoccerTeamProcessor
    {
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        private readonly IRegisterSoccerTeam _registerSoccerTeam;
        private readonly IGetSoccerTeam _getSoccerTeam;
        private readonly IGetAuthorizeSoccerGame _getAuthorizeSoccerGame;

        public SoccerTeamProcessor(
            IMapper mapper,
            IJwtUtils jwtUtils,
            IRegisterSoccerTeam registerSoccerTeam,
            IGetSoccerTeam SoccerTeam,
            IGetAuthorizeSoccerGame getAuthorizeUser
            )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtUtils = jwtUtils ?? throw new ArgumentNullException(nameof(jwtUtils));
            _registerSoccerTeam = registerSoccerTeam ?? throw new ArgumentNullException(nameof(registerSoccerTeam));
            _getSoccerTeam = SoccerTeam ?? throw new ArgumentNullException(nameof(SoccerTeam));
            _getAuthorizeSoccerGame = getAuthorizeUser ?? throw new ArgumentNullException(nameof(getAuthorizeUser));
        }
        public async Task<SoccerTeamStateResponse> RegisterSoccerTeamAsync(SoccerTeamRegisterRequest model)
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
        public async Task<SoccerTeamStateResponse> RegisterSoccerGameAsync(SoccerGameRegisterRequest model)
        {
            try
            {
                var soccerTeam = _mapper.Map<SoccerGame>(model);
                var items = await _registerSoccerTeam.RegisterSoccerGameAsync(soccerTeam);

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

        public async Task<SoccerTeamStateResponse> UpdateAsync(Guid id, SoccerGameRegisterRequest model)
        {
            var currentSoccerGame = await GetSoccerGameAsync(id);
            _mapper.Map(model, currentSoccerGame);

            var items = await _getAuthorizeSoccerGame.UpdateAsync(currentSoccerGame); 
            return new SoccerTeamStateResponse
            {
                Id = currentSoccerGame.Id,
                Items = items,
                Message = "Soccer game updated successfully"
            };
        }

        public async Task<SoccerTeamStateResponse> DeleteSoccerGameAsync(Guid id)
        {
            var currentSoccerGame = await GetSoccerGameAsync(id);
            var items = await _getAuthorizeSoccerGame.RemoveSoccerGameAsync(currentSoccerGame);

            return new SoccerTeamStateResponse
            {
                Id = currentSoccerGame.Id,
                Items = items,
                Message = "Soccer game deleted successfully"
            };
        }

        public async Task<SoccerTeamStateResponse> DeleteSoccerTeamAsync(Guid id)
        {
            var currentSoccerTeam = await GetSoccerTeamAsync(id);
            var items = await _getAuthorizeSoccerGame.RemoveSoccerTeamAsync(currentSoccerTeam);

            return new SoccerTeamStateResponse
            {
                Id = currentSoccerTeam.Id,
                Items = items,
                Message = "Soccer Team deleted successfully"
            };
        }


        private async Task<SoccerGame> GetSoccerGameAsync(Guid id)
        {
            var soccerGame = await _getAuthorizeSoccerGame.GetByIdSoccerGameAsync(id);
            if (soccerGame == null)
            {
                throw new KeyNotFoundException("Soccer game not found");
            }
            return soccerGame;
        }

        private async Task<SoccerTeam> GetSoccerTeamAsync(Guid id)
        {
            var soccerGame = await _getAuthorizeSoccerGame.GetByIdSoccerTeamAsync(id);
            if (soccerGame == null)
            {
                throw new KeyNotFoundException("Soccer Team not found");
            }
            return soccerGame;
        }
    }
}