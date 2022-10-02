using betting.soccer.scores.api.Domains;

namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public class SoccerGame : BaseEntity<Guid>
    {
        public string? TeamAId { get; set; }
        public string? TeamBId { get; set; }
        public DateTime? DateGame { get; set; }
        public byte? ScoreTeamA { get; set; }
        public byte? ScoreTeamB { get; set; }
    }
}
