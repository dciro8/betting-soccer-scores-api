using bettingsoccerscoresapi.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace betting.soccer.scores.api.Infraestructure
{
    public class SqlServerDataContext : DataContext
    {
        public SqlServerDataContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlServer(Configuration.GetConnectionString("ApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SoccerTeamConfiguration();
            modelBuilder.SoccerGameConfiguration();

        }
    }
}
