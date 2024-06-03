using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ENtityFrameWork_Test.Models.Account
{
    public class LoginRequestDto
    {
        [EmailAddress]
        public string Email{ get; set; }
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{6,}$", ErrorMessage ="Password Regex Error Message")]
        public string Password { get; set; }
    }
}
