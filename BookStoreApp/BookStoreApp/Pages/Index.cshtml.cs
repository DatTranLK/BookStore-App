using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Pages
{
    public class IndexModel : PageModel
    {

        public IList<Book> Books { get; set; }
        public IList<Store> Store { get; set; }
        public string Msg { get; set; }
        public Account Account { get; set; }

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IBookRepository _bookRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IBookInStoreRepository _bookInStoreRepository;


        public IndexModel(ILogger<IndexModel> logger, IBookRepository bookRepository, IStoreRepository storeRepository, IAccountRepository accountRepository, IBookInStoreRepository bookInStoreRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
            _storeRepository = storeRepository;
            _accountRepository = accountRepository;
            _bookInStoreRepository = bookInStoreRepository;
        }

        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            Books = _bookRepository.GetBooksInStore();
            if (Store == null)
            {
                Msg = "There is no store in here";
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                List<Book> bookSearchList = _bookRepository.SearchBook(SearchString.Trim()).ToList();
                Books = bookSearchList;
            }


        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Role");
            HttpContext.Session.Remove("cartCus");
            return RedirectToPage("/Login/LoginPage");
        }


    }
}
