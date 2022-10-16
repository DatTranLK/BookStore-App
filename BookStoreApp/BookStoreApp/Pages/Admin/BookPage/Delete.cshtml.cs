using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.BookPage
{
    public class DeleteModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAccountRepository _accountRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        public Book Book { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public DeleteModel(IBookRepository bookRepository, IAccountRepository accountRepository)
        {
            _bookRepository = bookRepository;
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

            Book = _bookRepository.GetBookById(id);

            if (Book == null)
            {
                Msg = "Does not see any book";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                Msg = "The id is null";
            }
            _bookRepository.RemoveBook(id);

            return RedirectToPage("./Index");
        }
    }
}
