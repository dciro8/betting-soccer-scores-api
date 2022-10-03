namespace betting.soccer.scores.api.Infraestructure
{
    public class AppSettings
    {
        public AuthSettings Auth { get; set; }       
    }
    public class AuthSettings
    {
        public string Secret { get; set; }
    }
}
