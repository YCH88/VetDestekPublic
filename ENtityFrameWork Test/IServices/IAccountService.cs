using ENtityFrameWork_Test.Models.Account;

namespace ENtityFrameWork_Test.IServices
{
    public interface IAccountService
    {
		Task<bool> Login(LoginRequestDto dto);

	}
}
