using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.Request
{
    public class EditModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRequestBookRepository _requestBookRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public string Msg { get; set; }
        public Account Account { get; set; }
        public IList<Store> Store { get; set; }
        public RequestBook RequestBook { get; set; }
        public EditModel(IAccountRepository accountRepository, IRequestBookRepository requestBookRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _requestBookRepository = requestBookRepository;
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
