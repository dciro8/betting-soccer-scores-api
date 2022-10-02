using Microsoft.AspNetCore.Mvc;

namespace betting.soccer.scores.api.Adapters.SoccerGameService
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
