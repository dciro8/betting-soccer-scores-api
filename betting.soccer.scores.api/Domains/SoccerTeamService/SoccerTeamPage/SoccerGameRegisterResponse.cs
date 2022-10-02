namespace betting.soccer.scores.api.Domains.SoccerTeamService.SoccerTeamPage
{
    public class SoccerGameRegisterResponse
    {
        public string? TeamAId { get; set; }
        public string? TeamBId { get; set; }
        public DateTime? DateGame { get; set; }
        public byte? ScoreTeamA { get; set; }
        public byte? ScoreTeamB { get; set; }
    }
}
