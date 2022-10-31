using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Repository;

namespace BookStoreApp.Pages.Admin.BookInStorePage
{
    public class EditModel : PageModel
    {
        private readonly BookStoreDBContext _context;
        private readonly IAccountRepository _accountRepository;
        private readonly IStoreRepository _storeRepository;

        public EditModel(BookStoreDBContext context, IAccountRepository accountRepository, IStoreRepository storeRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
            _storeRepository = storeRepository;
        }

        [BindProperty]
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
            ViewData["BookId"] = new SelectList(_context.Books, "Id", "Id");
            ViewData["StoreId"] = new SelectList(_context.Stores, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookInStore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookInStoreExists(BookInStore.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookInStoreExists(int id)
        {
            return _context.BookInStores.Any(e => e.Id == id);
        }
    }
}
