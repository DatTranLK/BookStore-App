using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Profile
{
    public class ProfileModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public Account AccountInfo { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public ProfileModel(IAccountRepository accountRepository, IStoreRepository storeRepository)
        {
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

            AccountInfo = _accountRepository.GetAccountById(id);

            if (AccountInfo == null)
            {
                Msg = "Does not see the account";
            }
            return Page();
        }
    }
}
