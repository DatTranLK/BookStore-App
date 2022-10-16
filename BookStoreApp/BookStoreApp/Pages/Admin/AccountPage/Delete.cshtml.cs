using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.AccountPage
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        public Account AccountInfo { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public DeleteModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            if (id == null)
            {
                Msg = "The id is null";
            }

            AccountInfo = _accountRepository.GetAccountById(id);

            if (AccountInfo == null)
            {
                Msg = "Does not see the account";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                Msg = "The id is null";
            }
            _accountRepository.RemoveAccount(id);

            return RedirectToPage("./Index");
        }
    }
}
