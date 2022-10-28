using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.Request
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IRequestBookDetailRepository _bookDetailRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public string Msg { get; set; }
        public Account Account { get; set; }
        public IList<RequestBookDetail> RequestBookDetail { get; set; }
        public IList<Store> Store { get; set; }


        public DetailsModel(IAccountRepository accountRepository, IRequestBookDetailRepository bookDetailRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _bookDetailRepository = bookDetailRepository;
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
            RequestBookDetail = _bookDetailRepository.GetRequestBookDetailByRequestId(id);
            if (RequestBookDetail == null)
            {
                Msg = "This Import does not exist!";
            }
            return Page();
        }
    }
}
