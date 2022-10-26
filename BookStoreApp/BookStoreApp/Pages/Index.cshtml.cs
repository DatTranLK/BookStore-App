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
            if (Store == null)
            {
                Msg = "There is no store in here";
            }
            if(Role == "3")
            {
                List<BookInStore> bookInStoreList = _bookInStoreRepository.GetBookInStores((int)Account.StoreId);
                List<Book> forSale = new List<Book>();
                foreach (BookInStore item in bookInStoreList)
                {
                    forSale.Add(item.Book);
                }
                Books = forSale;
            }
            else
            {
                Books = _bookRepository.GetBooksInStore();
                
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
