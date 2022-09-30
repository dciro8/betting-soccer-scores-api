using AutoMapper;
using bettingsoccerscoresapi.Domains.UserService.AuthorizationEntity;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Transenvios.Shipping.Api.Domains.UserService.AuthorizationEntity;
using Transenvios.Shipping.Api.Infraestructure;

namespace Transenvios.Shipping.Api.Domains.UserService.UserPage
{
    public class UserProcessor
    {
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;
        private readonly IRegisterUser _registerUser;
        private readonly IGetUser _getUser;
        private readonly IGetAuthorizeUser _getAuthorizeUser;

        public UserProcessor(
            IMapper mapper,
            IJwtUtils jwtUtils,
            IRegisterUser registerUser,
            IGetUser getUser,
            IGetAuthorizeUser getAuthorizeUser
            )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtUtils = jwtUtils ?? throw new ArgumentNullException(nameof(jwtUtils));
            _registerUser = registerUser ?? throw new ArgumentNullException(nameof(registerUser));
            _getUser = getUser ?? throw new ArgumentNullException(nameof(getUser));
            _getAuthorizeUser = getAuthorizeUser ?? throw new ArgumentNullException(nameof(getAuthorizeUser));
        }

        
        

        private async Task<SoccerTeam> GetUserAsync(Guid id)
        {
            var user = await _getAuthorizeUser.GetByIdAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            return user;
        }
        public async Task<UserStateResponse> PasswordResetAsync(string email)
        {
           
            return new UserStateResponse
            {
                Message = ""
            };
        }
    }
}