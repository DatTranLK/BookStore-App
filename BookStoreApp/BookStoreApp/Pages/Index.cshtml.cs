using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Book> Book { get; set; }

        public string Username { get; set; }
        public string Role { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly IBookRepository _bookRepository;

        public IndexModel(ILogger<IndexModel> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Book = _bookRepository.GetBooksInStore();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("Role");
            return RedirectToPage("/Login/LoginPage");
        }


    }
}
