using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreApp.Pages.Admin.StorePage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, ICategoryRepository categoryRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _storeRepository = storeRepository;
        }
        public List<Store> StoreAdminList { get; set; }
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
            Store = _storeRepository.GetStoresNoDes();
            StoreAdminList = _storeRepository.GetStores();
            if (StoreAdminList == null)
            {
                Msg = "There is no store in here";
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                List<Store> storeList = _storeRepository.SearchStore(SearchString.Trim()).ToList();
                StoreAdminList = storeList;
            }

        }
    }
}
