using bettingsoccerscoresapi.Domains.UserService.AuthorizationEntity;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Microsoft.EntityFrameworkCore;
using Transenvios.Shipping.Api.Domains.UserService.UserPage;
using Transenvios.Shipping.Api.Infraestructure;

namespace Transenvios.Shipping.Api.Mediators.UserService.UserPage
{
    public class UserMediator : IRegisterUser, IGetUser, IGetAuthorizeUser
    {
        private readonly DataContext _context;

        public UserMediator(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> RegisterAsync(SoccerTeam  user)
        {
            await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<IList<SoccerTeam >> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<SoccerTeam > GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
        
        public async Task<int> UpdateAsync(SoccerTeam  user)
        {
            _context.Users.Update(user);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(SoccerTeam  user)
        {
            _context.Users.Remove(user);
            return await _context.SaveChangesAsync();
        }
    }
}
