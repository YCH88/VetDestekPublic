using ENtityFrameWork_Test.Entities;
using ENtityFrameWork_Test.IServices;
using ENtityFrameWork_Test.Models.Account;
using ENtityFrameWork_Test.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ENtityFrameWork_Test.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;
		private readonly SignInManager<User> _signInManager;

		public AccountController(IAccountService accountService, SignInManager<User> signInManager)
		{
			_accountService = accountService;
			_signInManager = signInManager;
		}

		public IActionResult Login()
		{
			if (User?.Identity.IsAuthenticated is true)
				return RedirectToAction("Index", "Home");

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginRequestDto dto)
		{
			if (!ModelState.IsValid)
				return View();

			var request = await _accountService.Login(dto);

			if (request)
			{
				return RedirectToAction("Index","Home");
			}


        	return View();
		}

		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			return RedirectToAction("Login");
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
