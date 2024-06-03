using Microsoft.AspNetCore.Mvc;

namespace ENtityFrameWork_Test.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
