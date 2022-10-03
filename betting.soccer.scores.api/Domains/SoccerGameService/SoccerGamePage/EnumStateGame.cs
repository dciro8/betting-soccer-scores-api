using System.ComponentModel.DataAnnotations;

namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public enum EnumStateGame
    {
        [Display(Description = "Programer")] P,
        [Display(Description = "Game")]G,
        [Display(Description = "Finish")] F,
        [Display(Description = "Cancel")] C
    }
}
