using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;

namespace BookStoreApp.Pages.Scaffold
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObject.Models.BookStoreDBContext _context;

        public IndexModel(BusinessObject.Models.BookStoreDBContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books
                .Include(b => b.Category)
                .Include(b => b.Publisher).ToListAsync();
        }
    }
}
