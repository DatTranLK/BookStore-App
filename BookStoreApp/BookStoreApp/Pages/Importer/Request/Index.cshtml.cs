using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;

namespace BookStoreApp.Pages.Importer.Request
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRequestBookRepository _requestBookRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public string Msg { get; set; }
        public IList<Store> Store { get; set; }

        public IndexModel(IAccountRepository accountRepository, IRequestBookRepository requestBookRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _requestBookRepository = requestBookRepository;
            _storeRepository = storeRepository;
        }
        public Account Account { get; set; }
        public IList<RequestBook> RequestBooks { get; set; }
        public void OnGet(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            RequestBooks = _requestBookRepository.GetRequestBooks();
            Store = _storeRepository.GetStoresNoDes();        
            if (RequestBooks == null)
            {
                Msg = "No import history in here";
            }
        }
    }
}
