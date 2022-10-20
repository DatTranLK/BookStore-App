using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.BookPage
{
    public class DetailsModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public Book Book { get; set; }
        public Account Account { get; set; }
        public IList<Store> Store { get; set; }
        public string Msg { get; set; }
        public DetailsModel(IBookRepository bookRepository, IAccountRepository accountRepository, IStoreRepository storeRepository)
        {
            _bookRepository = bookRepository;
            _accountRepository = accountRepository;
            _storeRepository = storeRepository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            if (id == null)
            {
                Msg = "The id is null";
            }

            Book = _bookRepository.GetBookById(id);

            if (Book == null)
            {
                Msg = "Does not see the book";
            }
            return Page();
        }
    }
}
