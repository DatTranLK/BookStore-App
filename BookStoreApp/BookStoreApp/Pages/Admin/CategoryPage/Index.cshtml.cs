using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;

namespace BookStoreApp.Pages.Admin.CategoryPage
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, ICategoryRepository categoryRepository)
        {
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
        }
        public IList<Category> Category { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Category = _categoryRepository.GetCategories();
            if (Category == null)
            {
                Msg = "There is no category in here";
            }
        }
    }
}