using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreApp.Pages.Admin.BookPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, IBookRepository bookRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _bookRepository = bookRepository;
            _storeRepository = storeRepository;
        }
        public IList<Book> Book { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Book = _bookRepository.GetBooks();
            Store = _storeRepository.GetStoresNoDes();
            if (Store == null)
            {
                Msg = "There is no store in here";
            }
            if (Book == null)
            {
                Msg = "There is no book in here";
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                List<Book> bookSearchList = _bookRepository.SearchBook(SearchString.Trim()).ToList();
                Book = bookSearchList;
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
