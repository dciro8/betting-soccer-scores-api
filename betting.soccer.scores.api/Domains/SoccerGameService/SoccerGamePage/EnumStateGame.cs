using System.ComponentModel.DataAnnotations;

namespace betting.soccer.scores.api.Domains.SoccerGameService.SoccerGamePage
{
    public enum EnumStateGame
    {
        [Display(Description = "P")] Programer,
        [Display(Description = "G")] Game,
        [Display(Description = "F")] Finish,
        [Display(Description = "C")] Cancel
    }
}
