using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;

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
        public IList<Store> Store2 { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            Store2 = _storeRepository.GetStores();
            if (Store2 == null)
            {
                Msg = "There is no store in here";
            }
        }
    }
}
