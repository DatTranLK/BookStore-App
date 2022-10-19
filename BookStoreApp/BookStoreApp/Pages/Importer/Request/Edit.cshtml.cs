using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Importer.Request
{
    public class EditModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRequestBookRepository _requestBookRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public string Msg { get; set; }
        public Account Account { get; set; }
        public RequestBook RequestBook { get; set; }
        public EditModel(IAccountRepository accountRepository, IRequestBookRepository requestBookRepository)
        {
            _accountRepository = accountRepository;
            _requestBookRepository = requestBookRepository;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            if (id == null)
            {
                return NotFound();
            }
            RequestBook = _requestBookRepository.GetRequestById(id);
            if (RequestBook == null)
            {
                Msg = "This import does not existed!";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var import = _requestBookRepository.GetRequestById(RequestBook.Id);
            if (import == null)
            {
                Msg = "Can not find this import!";
                return Page();
            }
            if (RequestBook.CreateDate == null)
            {
                Msg = "Please select date";
                return Page();
            }
            if (!RequestBook.AddBookState.Equals("Done") || !RequestBook.AddBookState.Equals("Not Done"))
            {
                Msg = "Please input 2 status: Done or Not Done";
                return Page();
            }
            _requestBookRepository.UpdateImport(RequestBook);
            return RedirectToPage("./Index");
        }
    }
}
