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
                new SoccerTeam{ Id=Guid.NewGuid(), TeamCode= "ALE",TeamName= "Alemania"},
                new SoccerTeam{ Id=Guid.NewGuid(), TeamCode= "FRA",TeamName= "Francia"},
                new SoccerTeam{ Id=Guid.NewGuid(), TeamCode= "HOL",TeamName= "Holanda"},
                new SoccerTeam{ Id=Guid.NewGuid(), TeamCode= "CHI",TeamName= "Chile"},
                new SoccerTeam{ Id=Guid.NewGuid(), TeamCode= "BRA",TeamName= "Brazil"},
            };
            foreach (SoccerTeam s in soccerTeam)
            {
                context.SoccerTeams.Add(s);
            }
            context.SaveChanges();

            
        }
    }
}
