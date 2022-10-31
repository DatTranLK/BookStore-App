using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Repository;

namespace BookStoreApp.Pages.Admin.BookInStorePage
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        private readonly BookStoreDBContext _context;

        public CreateModel(BookStoreDBContext context, IAccountRepository accountRepository, IStoreRepository storeRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _storeRepository = storeRepository;
        }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }

        public IActionResult OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public BookInStore BookInStore { get; set; }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BookInStores.Add(BookInStore);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
