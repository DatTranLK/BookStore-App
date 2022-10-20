using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.AccountPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly BookStoreDBContext _context;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        [Required]
        public Account AccountInfo { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public CreateModel(IAccountRepository accountRepository, BookStoreDBContext context, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _context = context;
            _storeRepository = storeRepository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            ViewData["RoleId"] = new SelectList(_context.Roles, "Id", "Name");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Name");
            if (!ModelState.IsValid)
            {
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
            var checkexits = _accountRepository.GetAccountByUsername(AccountInfo.Username);
            if (checkexits != null)
            {
                Msg = "The username has exist please enter another username";
                return Page();
            }

            _accountRepository.CreateNewAccount(AccountInfo);

            return RedirectToPage("./Index");
        }
    }
}
 