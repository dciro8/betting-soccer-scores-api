using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Microsoft.EntityFrameworkCore;
using betting.soccer.scores.api.Domains.UserService.UserPage;
using betting.soccer.scores.api.Infraestructure;
using betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage;

namespace betting.soccer.scores.api.Mediators.UserService.UserPage
{
    public class SoccerTeamMediator : IRegisterSoccerTeam, IGetSoccerTeam, ISoccerTeam
    {
        private readonly DataContext _context;

        public SoccerTeamMediator(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<int> RegisterSoccerTeamAsync(SoccerTeam soccerTeam)
        {
            await _context.SoccerTeams.AddAsync(soccerTeam);
            return await _context.SaveChangesAsync();
        }
        public async Task<IList<SoccerTeam >> GetAllAsync()
        {
            return await _context.SoccerTeams.ToListAsync();
        }       

        public async Task<SoccerTeam> GetByIdSoccerTeamAsync(Guid id)
        {
            return await _context.SoccerTeams.FindAsync(id);
        }


        public async Task<int> RemoveSoccerTeamAsync(SoccerTeam soccerTeam)
        {
            _context.SoccerTeams.Remove(soccerTeam);
            return await _context.SaveChangesAsync();
        }
        public async Task<IList<SoccerTeam>> GetAllSoccerTeamAsync()
        {
            return await _context.SoccerTeams.ToListAsync();
        }
    }
}
