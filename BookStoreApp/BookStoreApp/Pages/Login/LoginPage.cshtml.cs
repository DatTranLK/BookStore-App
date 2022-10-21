using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Login
{
    public class LoginPageModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        [BindProperty]
        [Required]
        public string Username { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
        public LoginPageModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
         
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            var account = _accountRepository.CheckLogin(Username, Password);
            if (account != null)
            {
                if(account.RoleId == 1)
                {
                    HttpContext.Session.SetString("Username", account.Username);
                    HttpContext.Session.SetString("Role", account.RoleId.ToString());
                    return RedirectToPage("/Admin/BookPage/Index");
                }
                if ( account.RoleId == 2)
                {
                    HttpContext.Session.SetString("Username", account.Username);
                    HttpContext.Session.SetString("Role", account.RoleId.ToString());
                    return RedirectToPage("/Importer/ImportPage/Index");
                }
                if (account.RoleId == 3)
                {
                    HttpContext.Session.SetString("Username", account.Username);
                    HttpContext.Session.SetString("Role", account.RoleId.ToString());
                    return RedirectToPage("/Seller/SellerPage");
                }
                 if (account.RoleId == 4)
                 {
                    HttpContext.Session.SetString("Username", account.Username);
                    HttpContext.Session.SetString("Role", account.RoleId.ToString());
                    return RedirectToPage("/Index");
                 }
                
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid email or password.";
                return Page();
            }

            return Page();
        }
    }
}
