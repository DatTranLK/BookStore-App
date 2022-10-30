using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreApp.Pages.Admin.PublisherPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, IPublisherRepository publisherRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _publisherRepository = publisherRepository;
            _storeRepository = storeRepository;
        }
        public List<Publisher> Publisher { get; set; }
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
            Publisher = _publisherRepository.GetPublishers();
            if (Publisher == null)
            {
                Msg = "There is no publisher in here";
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                List<Publisher> publisherSearchList = _publisherRepository.SearchPublisher(SearchString.Trim()).ToList();
                Publisher = publisherSearchList;
            }
        }
    }
}
