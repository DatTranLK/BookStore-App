using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.AccountPage
{
    public class EditModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly BookStoreDBContext _context;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        [Required]
        public Account AccountInfo { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public EditModel(IAccountRepository accountRepository, BookStoreDBContext context)
        {
            _accountRepository = accountRepository;
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name");
            if (id == null)
            {
                Msg = "The id is null";
            }

            AccountInfo = _accountRepository.GetAccountById(id);

            if (AccountInfo == null)
            {
                Msg = "Does not see any account";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var checkExit = _accountRepository.GetAccountById(AccountInfo.Id);
            if (checkExit == null)
            {
                Msg = "Can not see the account with id: " + AccountInfo.Id;
                return Page();
            }
            if (string.IsNullOrEmpty(AccountInfo.Username) || string.IsNullOrEmpty(AccountInfo.Password)
                || string.IsNullOrEmpty(AccountInfo.Name) || string.IsNullOrEmpty(AccountInfo.Avatar)
                || string.IsNullOrEmpty(AccountInfo.Phone.ToString()) || string.IsNullOrEmpty(AccountInfo.DateOfBirth.ToString())
                || string.IsNullOrEmpty(AccountInfo.Address))
            {
                Msg = "Please enter username, password, name, avatar, phone, dateofbirth or address";
                return Page();
            }
            _accountRepository.UpdateAccount(AccountInfo);

            return RedirectToPage("./Index");
        }
    }
}
