
using betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage;
using bettingsoccerscoresapi.Domains.UserService.UserPage;
using Microsoft.EntityFrameworkCore;

namespace betting.soccer.scores.api.Infraestructure
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public virtual DbSet<SoccerTeam >? SoccerTeams { get; set; }
        public virtual DbSet<SoccerGame>? SoccerGames { get; set; }


        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            options.UseSqlServer(Configuration.GetConnectionString("ApiDatabase"));
        }
    }
}
