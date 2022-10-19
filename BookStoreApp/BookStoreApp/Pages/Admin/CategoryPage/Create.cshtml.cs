using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.CategoryPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly BookStoreDBContext _context;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        [Required]
        public Category Category { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public CreateModel(IAccountRepository accountRepository, BookStoreDBContext context, ICategoryRepository categoryRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _context = context;
            _categoryRepository = categoryRepository;
            _storeRepository = storeRepository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (string.IsNullOrEmpty(Category.Name) || string.IsNullOrEmpty(Category.Description))
            {
                Msg = "Please enter Name or Description";
                return Page();
            }
            _categoryRepository.CreateNewCategory(Category);

            return RedirectToPage("./Index");
        }
    }
}
