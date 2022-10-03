namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public class SoccerGameResponse
    {
        public string? TeamAId { get; set; }
        public string? TeamBId { get; set; }
        public DateTime? DateGame { get; set; }
        public int? ScoreTeamA { get; set; }
        public int? ScoreTeamB { get; set; }
        public string? Status { get; set; }

    }
}
