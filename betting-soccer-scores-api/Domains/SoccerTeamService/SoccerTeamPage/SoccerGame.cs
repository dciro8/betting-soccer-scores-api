using Transenvios.Shipping.Api.Domains;

namespace bettingsoccerscoresapi.Domains.SoccerTeamService.SoccerTeamPage
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
