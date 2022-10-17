using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.PublisherPage
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IPublisherRepository _publisherRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        [BindProperty]
        public Publisher Publisher { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public DeleteModel(IAccountRepository accountRepository, IPublisherRepository publisherRepository)
        {
            _accountRepository = accountRepository;
            _publisherRepository = publisherRepository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            if (id == null)
            {
                Msg = "The id is null";
            }

            Publisher = _publisherRepository.GetPublisherById(id);

            if (Publisher == null)
            {
                Msg = "Does not see any publisher";
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                Msg = "The id is null";
            }
            _publisherRepository.RemovePublisher(id);

            return RedirectToPage("./Index");
        }
    }
}
