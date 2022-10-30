using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.BookInStorePage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookInStoreRepository _bookInStoreRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, IBookInStoreRepository bookInStoreRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _bookInStoreRepository = bookInStoreRepository;
            _storeRepository = storeRepository;
        }
        public IList<BookInStore> BookInStore { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public async Task OnGetAsync(int id)
        {

            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            BookInStore = _bookInStoreRepository.GetBookInStores(id);
            if (BookInStore == null)
            {
                Msg = "There is no BookInStore in here";
            }
           
        }
        public void OnPost(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            BookInStore = _bookInStoreRepository.GetBookInStores(id);
            if (!string.IsNullOrEmpty(SearchString))
            {
                SearchString = SearchString.Trim();
                List<BookInStore> bookInStoreSearchList = BookInStore.Where(o => o.Book.Name.Contains(SearchString)
                || o.Amount.ToString().Contains(SearchString)
                ).ToList();
                BookInStore = bookInStoreSearchList;
            }
        }
    }
}
