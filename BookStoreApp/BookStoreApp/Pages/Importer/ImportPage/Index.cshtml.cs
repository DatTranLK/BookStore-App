using BookStoreApp.Helper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Importer.ImportPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Msg { get; set; }
        public string Role { get; set; }
        public List<Item> cart;
        public IndexModel(IAccountRepository accountRepository, IBookRepository bookRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _bookRepository = bookRepository;
            _storeRepository = storeRepository;
        }
        public Account Account { get; set; }
        public List<Book> Book { get; set; }
        public IList<Store> Store { get; set; }

        public async Task OnGetAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Book = _bookRepository.GetBooks();
            Store = _storeRepository.GetStoresNoDes();
            if (Book == null)
            {
                Msg = "Do not have any book!";
            }

            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login/LoginPage");
        }
    }
}
