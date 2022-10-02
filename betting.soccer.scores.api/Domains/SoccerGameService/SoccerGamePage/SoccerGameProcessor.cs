using AutoMapper;
using betting.soccer.scores.api.Domains.Generic;
using betting.soccer.scores.api.Domains.UserService.AuthorizationEntity;

namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public class SoccerGameProcessor
    {
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        private readonly IRegisterSoccerGame _registerSoccerGame;        
        private readonly ISoccerGame _soccerGame;

        public SoccerGameProcessor(
         IMapper mapper,
         IJwtUtils jwtUtils,
         IRegisterSoccerGame registerSoccerGame,         
         ISoccerGame soccerGame
         )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtUtils = jwtUtils ?? throw new ArgumentNullException(nameof(jwtUtils));
            _registerSoccerGame = registerSoccerGame ?? throw new ArgumentNullException(nameof(registerSoccerGame));   
            _soccerGame = soccerGame ?? throw new ArgumentNullException(nameof(soccerGame));
        }

        public async Task<IList<SoccerGameResponse>> GetAllSoccerGameAsync()
        {
            var response = await _soccerGame.GetAllSoccerGameAsync();
            var soccerGame = _mapper.Map<IList<SoccerGameResponse>>(response);
            return soccerGame;
        }
        public async Task<SoccerTeamStateResponse> RegisterSoccerGameAsync(SoccerGameResponse model)
        {
            try
            {
                var soccerTeam = _mapper.Map<SoccerGame>(model);
                var items = await _registerSoccerGame.RegisterSoccerGameAsync(soccerTeam);

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
        private async Task<SoccerGame> GetSoccerGameAsync(Guid id)
        {
            var soccerGame = await _soccerGame.GetByIdSoccerGameAsync(id);
            if (soccerGame == null)
            {
                throw new KeyNotFoundException("Soccer game not found");
            }
            return soccerGame;
        }
        public async Task<SoccerTeamStateResponse> DeleteSoccerGameAsync(Guid id)
        {
            var currentSoccerGame = await GetSoccerGameAsync(id);
            var items = await _soccerGame.RemoveSoccerGameAsync(currentSoccerGame);

            return new SoccerTeamStateResponse
            {
                Id = currentSoccerGame.Id,
                Items = items,
                Message = "Soccer game deleted successfully"
            };
        }
        public async Task<SoccerTeamStateResponse> UpdateAsync(Guid id, SoccerGameResponse model)
        {
            var currentSoccerGame = await GetSoccerGameAsync(id);
            _mapper.Map(model, currentSoccerGame);

            var items = await _soccerGame.UpdateAsync(currentSoccerGame);
            return new SoccerTeamStateResponse
            {
                Id = currentSoccerGame.Id,
                Items = items,
                Message = "Soccer game updated successfully"
            };
        }
    }
}
