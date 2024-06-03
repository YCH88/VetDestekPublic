using ENtityFrameWork_Test.Entities;
using ENtityFrameWork_Test.Extensions;
using ENtityFrameWork_Test.IServices;
using ENtityFrameWork_Test.Models;
using ENtityFrameWork_Test.Models.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;

namespace ENtityFrameWork_Test.Services
{
    public class AccountService : IAccountService
    {
        private readonly TestContext _dbContext;
        private readonly SignInManager<User> _signInManager; 
        private readonly UserManager<User> _userManager; 

        public AccountService(TestContext dbContext,SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
		}
		public async Task<bool> Login(LoginRequestDto dto)
        {
			var result = await _signInManager.PasswordSignInAsync(dto.Email,dto.Password,false,false);
            return result.Succeeded;
		}
    }
}
