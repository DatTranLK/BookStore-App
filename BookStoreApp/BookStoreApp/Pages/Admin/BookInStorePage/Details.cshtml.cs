using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Repository;
using Microsoft.AspNetCore.Http;

namespace BookStoreApp.Pages.Admin.BookInStorePage
{
    public class DetailsModel : PageModel
    {
        private readonly BookStoreDBContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly IStoreRepository _storeRepository;
        public DetailsModel(BookStoreDBContext context, IAccountRepository accountRepository, IStoreRepository storeRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _storeRepository = storeRepository;
        }

        public BookInStore BookInStore { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            if (id == null)
            {
                return NotFound();
            }

            BookInStore = await _context.BookInStores
                .Include(b => b.Book)
                .Include(b => b.Store).FirstOrDefaultAsync(m => m.Id == id);

            if (BookInStore == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
