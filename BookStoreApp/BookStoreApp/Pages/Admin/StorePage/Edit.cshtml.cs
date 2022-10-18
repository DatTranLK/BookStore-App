using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.StorePage
{
    public class EditModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly BookStoreDBContext _context;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        [Required]
        public Store Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public EditModel(IAccountRepository accountRepository, BookStoreDBContext context, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _context = context;
            _storeRepository = storeRepository;
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

            Store = _storeRepository.GetStoreById(id);

            if (Store == null)
            {
                Msg = "Does not see any store";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (string.IsNullOrEmpty(Store.Name) || string.IsNullOrEmpty(Store.Address))
            {
                Msg = "Please enter Name or Address";
                return Page();
            }
            _storeRepository.UpdateStore(Store);
            return RedirectToPage("./Index");
        }
    }
}
