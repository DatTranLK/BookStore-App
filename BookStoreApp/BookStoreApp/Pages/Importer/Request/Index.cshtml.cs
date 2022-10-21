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

        public string Username { get; set; }
        public string Role { get; set; }
        public string Msg { get; set; }
        public IndexModel(IAccountRepository accountRepository, IRequestBookRepository requestBookRepository)
        {
            _accountRepository = accountRepository;
            _requestBookRepository = requestBookRepository;
        }
        public Account Account { get; set; }
        public IList<RequestBook> RequestBooks { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            RequestBooks = _requestBookRepository.GetRequestBooks();
            if (RequestBooks == null)
            {
                Msg = "No import history in here";
            }
        }
    }
}
