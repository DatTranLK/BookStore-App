using BookStoreApp.ValidationHandling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Login
{
    public class LoginPageModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly LoginValidation _loginValidation;

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string Msg { get; set; }
        public string Role { get; set; }
        public LoginPageModel(IAccountRepository accountRepository, LoginValidation loginValidation)
        {
            _accountRepository = accountRepository;
            _loginValidation = loginValidation;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        { 
            var validate = _loginValidation.CheckValidationLoginForm(Username, Password);
            if (validate != "ok")
            {
                Msg = validate;
                return Page();
            }
            var account = _accountRepository.CheckLogin(Username, Password);
            if (account != null && account.RoleId == 1)
            {
                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Role", account.RoleId.ToString());
                return RedirectToPage("/Admin/AdminPage");
            }
            else if (account != null && account.RoleId == 2)
            {
                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Role", account.RoleId.ToString());
                return RedirectToPage("/Importer/ImporterPage");
            }
            else if (account != null && account.RoleId == 3)
            {
                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Role", account.RoleId.ToString());
                return RedirectToPage("/Seller/SellerPage");
            }
            else if (account != null && account.RoleId == 4)
            {
                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetString("Role", account.RoleId.ToString());
                return RedirectToPage("/Index");
            }
            else {
                Msg = "Username or password are not correct, Please enter again";
                return Page();
            }
            return Page();
        }
    }
}
