using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;

namespace BookStoreApp.Pages.Admin.BookPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookRepository _bookRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, IBookRepository bookRepository)
        {
            _accountRepository = accountRepository;
            _bookRepository = bookRepository;
        }
        public IList<Book> Book { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Book = _bookRepository.GetBooks();
            if (Book == null)
            {
                Msg = "There is no book in here";
            }
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login/LoginPage");
        }
    }
}
