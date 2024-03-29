using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.Request
{
    public class DeleteModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRequestBookDetailRepository _bookDetailRepository;
        private readonly IRequestBookRepository _bookRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public string Msg { get; set; }
        public Account Account { get; set; }
        public RequestBook RequestBook { get; set; }
        public IList<Store> Store { get; set; }
        public DeleteModel(IAccountRepository accountRepository, IRequestBookDetailRepository bookDetailRepository, IRequestBookRepository bookRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _bookDetailRepository = bookDetailRepository;
            _bookRepository = bookRepository;
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
                Msg = "Not Found!";
            }
            RequestBook = _bookRepository.GetRequestById(id);
            if (RequestBook == null)
            {
                Msg = "This import does not exist!";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                Msg = "The id is null";
            }
            _bookDetailRepository.DeleteRequestDetails(id);
            _bookRepository.DeleteImportById(id);

            return RedirectToPage("./Index");
        }
    }
}
