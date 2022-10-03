using AutoMapper;
using betting.soccer.scores.api.Domains.Generic;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;
using betting.soccer.scores.api.Domains.UserService.AuthorizationEntity;
using betting.soccer.scores.api.Domains.UserService.UserPage;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection.Metadata.Ecma335;

namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public class SoccerGameProcessor
    {
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        private readonly IRegisterSoccerGame _registerSoccerGame;
        private readonly ISoccerGame _soccerGame;
        private readonly ISoccerTeam _soccerTeam;
        private SoccerGame _currentSoccerGame;
        private string _nameTeam;

        public SoccerGameProcessor(
         IMapper mapper,
         IJwtUtils jwtUtils,
         IRegisterSoccerGame registerSoccerGame,
         ISoccerGame soccerGame,
         ISoccerTeam soccerTeam
         )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtUtils = jwtUtils ?? throw new ArgumentNullException(nameof(jwtUtils));
            _registerSoccerGame = registerSoccerGame ?? throw new ArgumentNullException(nameof(registerSoccerGame));
            _soccerGame = soccerGame ?? throw new ArgumentNullException(nameof(soccerGame));
            _soccerTeam = soccerTeam ?? throw new ArgumentNullException(nameof(soccerTeam));
        }

        public async Task<IList<SoccerGameResponse>> GetAllSoccerGameAsync()
        {
            var response = await _soccerGame.GetAllSoccerGameAsync();
            var soccerGame = _mapper.Map<IList<SoccerGameResponse>>(response);
            return soccerGame;
        }

        private async Task<SoccerTeamStateResponse> existTeams(SoccerGameResponse model)
        {
            var soccerGame = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(model.TeamAId));
            if (soccerGame == null)
            {
                return new SoccerTeamStateResponse
                {
                    Message = $"{SoccerGameConstants.SoccerGameNotFound} Team 1"
                };

            }

            soccerGame = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(model.TeamBId));
            if (soccerGame == null)
            {
                return new SoccerTeamStateResponse
                {
                    Message = $"{SoccerGameConstants.SoccerGameNotFound} Team 2"
                };
            }
            return null;
        }
        /// <summary>
        /// Validacón de la fecha 
        /// </summary>
        /// <param name="soccerGames"></param>
        /// <param name="currentDateGame"></param>
        /// <returns></returns>
        public bool IsWithinTime(IList<SoccerGame> soccerGames, DateTime currentDateGame)
        {
            foreach (var item in soccerGames)
            {
                if ((currentDateGame.Date <= item.DateGame.Value.Date) && (currentDateGame.Date >= item.DateGame.Value.Date))
                {
                    _currentSoccerGame = item;

                    return true;
                }
            }

            return false;
        }
        private async Task<SoccerTeamStateResponse> ValidateGame(SoccerGameResponse model)
        {
            if (!model.DateGame.Value.ToShortDateString().Contains(DateTime.Now.Date.ToShortDateString()))
            {
                return new SoccerTeamStateResponse
                {
                    Message = string.Format(SoccerGameConstants.CurrentDateNotMatch)
                };
            }

            IList<SoccerGame> soccerTeamA = await _soccerGame.GetListByIdSoccerGameAAsync(Guid.Parse(model.TeamAId));
            IList<SoccerGame> soccerTeamB = await _soccerGame.GetListByIdSoccerGameBAsync(Guid.Parse(model.TeamBId));

            SoccerTeam soccerTeam1 = new SoccerTeam();
            SoccerTeam soccerTeam2 = new SoccerTeam();

            //Exist TeamA
            if (soccerTeamA != null && soccerTeamA.Count > 0)
            {
                if (IsWithinTime(soccerTeamA, model.DateGame.Value))
                {
                    soccerTeam1 = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(_currentSoccerGame.TeamAId));
                    soccerTeam2 = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(_currentSoccerGame.TeamBId));

                    _nameTeam = string.Concat(soccerTeam1.TeamName, " o ", soccerTeam2.TeamName);
                    return new SoccerTeamStateResponse
                    {
                        Message = string.Format(SoccerGameConstants.GameThatDay, _nameTeam)
              
                    };
                }
                foreach (var teamA in soccerTeamA)
                {
                    if (model.TeamAId == teamA.TeamAId && model.TeamBId == teamA.TeamBId && model.DateGame == teamA.DateGame)
                    {
                        soccerTeam1 = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(model.TeamAId));
                        soccerTeam2 = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(model.TeamBId));

                        return new SoccerTeamStateResponse
                        {
                            Message = string.Format(SoccerGameConstants.ProgrammingHappened, soccerTeam1.TeamName, soccerTeam2.TeamName, model.DateGame)
                        };
                    }
                }
            }
            //Exist TeamB
            if (soccerTeamB != null && soccerTeamB.Count > 0)
            {
                if (IsWithinTime(soccerTeamB, model.DateGame.Value))
                {
                    soccerTeam1 = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(model.TeamAId));
                    soccerTeam2 = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(model.TeamBId));

                    _nameTeam = string.Concat(soccerTeam1.TeamName, " o ", soccerTeam2.TeamName);
                    return new SoccerTeamStateResponse
                    {
                        Message = string.Format(SoccerGameConstants.GameThatDay, _nameTeam)
                    };
                }
                foreach (var teamB in soccerTeamB)
                {
                    if (model.TeamAId == teamB.TeamAId && model.TeamBId == teamB.TeamBId && model.DateGame == teamB.DateGame)
                    {
                        return new SoccerTeamStateResponse
                        {
                            Message = string.Format(SoccerGameConstants.ProgrammingHappened, soccerTeam1.TeamName, soccerTeam2.TeamName, model.DateGame)
                        };
                    }
                }

            }
            return null;
        }

        public async Task<SoccerTeamStateResponse> RegisterSoccerGameAsync(SoccerGameResponse game)
        {
            try
            {
                //Validar TeamAId,TeambId  que exista
                await existTeams(game);

                SoccerTeamStateResponse resultValidate = await ValidateGame(game);

                if (resultValidate != null && !String.IsNullOrEmpty(resultValidate.Message))
                {
                    return resultValidate;
                }
                game.Status = EnumStateGame.P.ToString();

                //var soccerGame = _mapper.Map<SoccerGame>(game);

                SoccerGame soccerGame = new SoccerGame();
                soccerGame.TeamAId = game.TeamAId;
                soccerGame.TeamBId = game.TeamBId;
                soccerGame.DateGame = game.DateGame;
                soccerGame.ScoreTeamA = byte.Parse( game.ScoreTeamA.ToString());
                soccerGame.ScoreTeamB = byte.Parse(game.ScoreTeamB.ToString());

                var items = await _registerSoccerGame.RegisterSoccerGameAsync(soccerGame);

                return new SoccerTeamStateResponse
                {
                    Id = soccerGame.Id,
                    Items = items,
                    Message = SoccerGameConstants.Registration
                };
            }
            catch (Exception ex)
            {
                return new SoccerTeamStateResponse
                {
                    Items= 500,
                    Message = ex.GetBaseException().Message
                };
            }
        }
        private async Task<SoccerGame> GetSoccerGameAsync(Guid id)
        {
            var soccerGame = await _soccerGame.GetByIdSoccerGameAsync(id);
            if (soccerGame == null)
            {
                throw new KeyNotFoundException(SoccerGameConstants.SoccerGameNotFound);
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
                Message = SoccerGameConstants.GameDelete
            };
        }
        public async Task<SoccerTeamStateResponse> UpdateAsync(Guid id, SoccerGameResponse model)
        {
            //Validar TeamAId,TeambId  que exista           

            if (model.ScoreTeamA < 0)
            {
                var soccerTeam1 = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(model.TeamAId));                

                return new SoccerTeamStateResponse
                {
                    Message = String.Format(SoccerGameConstants.MarkerBeNegative, soccerTeam1.TeamName)
                };
            }

            if (model.ScoreTeamB < 0)
            {
                var soccerTeam2 = await _soccerTeam.GetByIdSoccerTeamAsync(Guid.Parse(model.TeamBId));

                return new SoccerTeamStateResponse
                {
                    Message = String.Format(SoccerGameConstants.MarkerBeNegative, soccerTeam2.TeamName)
                };
            }

            var currentSoccerGame = await GetSoccerGameAsync(id);
            _mapper.Map(model, currentSoccerGame);

            var items = await _soccerGame.UpdateAsync(currentSoccerGame);
            return new SoccerTeamStateResponse
            {
                Id = currentSoccerGame.Id,
                Items = items,
                Message = SoccerGameConstants.GameUpdate
            };
        }
    }
}
