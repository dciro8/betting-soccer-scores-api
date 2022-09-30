using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace Transenvios.Shipping.Api.Domains.UserService.UserPage
{
    public interface IGetUser
    {
        Task<IList<SoccerTeam >> GetAllAsync();
    }
}
