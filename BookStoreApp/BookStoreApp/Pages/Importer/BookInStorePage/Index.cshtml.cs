using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Importer.BookInStorePage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookInStoreRepository _bookInStoreRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IBookRepository _bookRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, IBookInStoreRepository bookInStoreRepository, IStoreRepository storeRepository, IBookRepository bookRepository)
        {
            _accountRepository = accountRepository;
            _bookInStoreRepository = bookInStoreRepository;
            _storeRepository = storeRepository;
            _bookRepository = bookRepository;
        }
        public IList<BookInStore> BookInStore { get; set; }
        public IList<Store> Store { get; set; }
        public int StoreId { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public async Task OnGetAsync(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            StoreId = id;
            HttpContext.Session.SetString("StoreId", id.ToString());
            BookInStore = _bookInStoreRepository.GetBookInStores(id);
            HttpContext.Session.SetString("Storeee", id.ToString());
            if (BookInStore == null)
            {
                Msg = "There is no BookInStore in here";
            }
        }
    }
}
