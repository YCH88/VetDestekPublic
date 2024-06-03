using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ENtityFrameWork_Test.Controllers
{

    [Authorize(Roles ="Admin")]
	public class AdminController:Controller
	{
        public AdminController()
        {
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
