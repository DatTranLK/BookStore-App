using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.PublisherPage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly BookStoreDBContext _context;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        [Required]
        public Publisher Publisher { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public CreateModel(IAccountRepository accountRepository, BookStoreDBContext context, IPublisherRepository publisherRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _context = context;
            _publisherRepository = publisherRepository;
            _storeRepository = storeRepository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (string.IsNullOrEmpty(Publisher.Name))
            {
                Msg = "Please enter Name";
                return Page();
            }
            _publisherRepository.CreateNewPublisher(Publisher);

            return RedirectToPage("./Index");
        }
    }
}
