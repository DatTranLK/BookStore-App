using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Importer.BookPage
{
    public class CreateModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly BookStoreDBContext _context;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        [Required]
        public Book Book { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public CreateModel(IBookRepository bookRepository, IAccountRepository accountRepository, BookStoreDBContext context, IStoreRepository storeRepository)
        {
            _bookRepository = bookRepository;
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "Id", "Name");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (string.IsNullOrEmpty(Book.Name) || string.IsNullOrEmpty(Book.Isbn) || string.IsNullOrEmpty(Book.Avatar)
                || string.IsNullOrEmpty(Book.Author) || string.IsNullOrEmpty(Book.Amount.ToString()))
            {
                Msg = "Please enter the name or isbn or avatar or author or amount, do not make them empty";
                return Page();
            }

            if (Book.Amount <= 0)
            {
                Msg = "Please enter the amount of book more than 1";
                return Page();
            }
            _bookRepository.CreateNewBook(Book);

            return RedirectToPage("./Index");
        }
    }
}
