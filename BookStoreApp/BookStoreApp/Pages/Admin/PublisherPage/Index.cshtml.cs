using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;

namespace BookStoreApp.Pages.Admin.PublisherPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPublisherRepository _publisherRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, IPublisherRepository publisherRepository)
        {
            _accountRepository = accountRepository;
            _publisherRepository = publisherRepository;
        }
        public IList<Publisher> Publisher { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Publisher = _publisherRepository.GetPublishers();
            if (Publisher == null)
            {
                Msg = "There is no publisher in here";
            }
        }
    }
}
