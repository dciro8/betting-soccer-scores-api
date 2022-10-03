using bettingsoccerscoresapi.Domains.UserService.UserPage;

namespace betting.soccer.scores.api.Infraestructure
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context, IWebHostEnvironment env)
        {
            context.Database.EnsureCreated();
            
            //Preload Data
            if (context.SoccerTeams.Any())
            {
                return;  //DataBase has been seed.
            }

            var soccerTeam = new SoccerTeam[]
            {
                new SoccerTeam{ Id=Guid.Parse("5F0FAF82-EA61-40A7-E1E3-08DAA3B22242"), TeamCode= "ALE",TeamName= "Alemania"},
                new SoccerTeam{ Id=Guid.Parse("5A001F2A-B545-453A-B531-08DAA4740421"), TeamCode= "FRA",TeamName= "Francia"},
                new SoccerTeam{ Id=Guid.Parse("4C34F0DF-A038-4D63-853F-46A93B90A1B3"), TeamCode= "HOL",TeamName= "Holanda"},
                new SoccerTeam{ Id=Guid.Parse("CF3F4AC3-FD22-41DF-9D6F-8F90ABA33205"), TeamCode= "CHI",TeamName= "Chile"},
                new SoccerTeam{ Id=Guid.Parse("A3921F88-C4B2-467D-AB68-AEDAD1873D69"), TeamCode= "BRA",TeamName= "Brazil"},
            };
            foreach (SoccerTeam s in soccerTeam)
            {
                context.SoccerTeams.Add(s);
            }
            context.SaveChanges();

            
        }
    }
}
