using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Register
{
    public class RegisterPageModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public string Msg { get; set; }

        [BindProperty]
        public Account Account { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }
        public RegisterPageModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
        }
        public async Task<IActionResult> OnPost()
        {
        
            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                Msg = "Please enter Confirm password field";
                return Page();
            }
            if (!Account.Password.Equals(ConfirmPassword))
            {
                Msg = "Confirm Password must match Password";
                return Page();
            }
            var checkExist = _accountRepository.GetAccountByUsername(Account.Username);
            if (checkExist != null)
            {
                Msg = "The username has existed, Please enter new username";
                return Page();
            }
            _accountRepository.Register(Account);
            HttpContext.Session.SetString("Username", Account.Username);
            HttpContext.Session.SetString("Role", Account.RoleId.ToString());
            return RedirectToPage("/Customer/CustomerPage");
        }
    }
}