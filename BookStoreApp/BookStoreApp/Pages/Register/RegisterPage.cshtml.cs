using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Register
{
    public class RegisterPageModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        [BindProperty]
        [Required]
        public string Username { get; set; }
        [BindProperty]
        [Required]
        public string Password { get; set; }
        [BindProperty]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public RegisterPageModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var checkExist = _accountRepository.GetAccountByUsername(Username);
            if (checkExist != null)
            {
                ViewData["ErrorMessage"] = "The username has existed, Please enter new username";
                return Page();
            }
            if (Password != ConfirmPassword)
            {
                ViewData["ErrorMessage"] = "The password must match confirm password";
                return Page();
            }
            Account currentAccount = _accountRepository.Register(new Account(Username,Password));

            if(currentAccount != null)
            {
                HttpContext.Session.SetString("Username", currentAccount.Username);
                HttpContext.Session.SetString("Role", currentAccount.RoleId.ToString());
                return RedirectToPage("/Index");
            }
            return Page();

        }
    }
}