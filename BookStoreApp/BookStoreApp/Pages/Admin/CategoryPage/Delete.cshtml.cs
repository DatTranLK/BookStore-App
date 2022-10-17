using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.CategoryPage
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        public Category Category { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public DeleteModel(IAccountRepository accountRepository, ICategoryRepository categoryRepository)
        {
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
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

            Category = _categoryRepository.GetCategoryById(id);

            if (Category == null)
            {
                Msg = "Does not see the category";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                Msg = "The id is null";
            }
            _categoryRepository.DeleteCategory(id);

            return RedirectToPage("./Index");
        }
    }
}
