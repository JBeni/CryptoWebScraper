using Microsoft.AspNetCore.Mvc;

namespace CryptoWebScraper.Controllers
{
    public class WebScraperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
