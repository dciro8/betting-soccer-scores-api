using bettingsoccerscoresapi.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace Transenvios.Shipping.Api.Infraestructure
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
