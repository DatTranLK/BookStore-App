using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BookStoreApp.Pages.Importer
{
    public class ImporterPageModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public ImporterPageModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Account Account { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);

        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login/LoginPage");
        }
    }
}
