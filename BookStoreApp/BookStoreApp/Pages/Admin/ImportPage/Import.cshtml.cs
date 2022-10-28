using BookStoreApp.Helper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.ImportPage
{
    public class ImportModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IRequestBookRepository _requestBook;
        private readonly IRequestBookDetailRepository _requestBookDetailRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public List<Item> cart { get; set; }
        public IList<Store> Store { get; set; }

        public ImportModel(IBookRepository bookRepository, IAccountRepository accountRepository, IRequestBookRepository requestBook, IRequestBookDetailRepository requestBookDetailRepository, IStoreRepository storeRepository)
        {
            _bookRepository = bookRepository;
            _accountRepository = accountRepository;
            _requestBook = requestBook;
            _requestBookDetailRepository = requestBookDetailRepository;
            _storeRepository = storeRepository;
        }
        public Account Account { get; set; }


        public void OnGet(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            var book = _bookRepository.GetBookById(id);
            if (cart == null)
            {
                cart = new List<Item>();
                cart.Add(new Item
                {
                    Book = book,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }
            else
            {
                int index = Exists(cart, id);
                if (index == -1)
                {
                    cart.Add(new Item
                    {
                        Book = book,
                        Quantity = 1
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
        }

        public void OnGetDelete(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }
        private int Exists(List<Item> cart, int id)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Book.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }

        public void OnGetIncrease(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart[index].Quantity++;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }

        public void OnGetDecrease(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = Exists(cart, id);
            cart[index].Quantity--;
            if (cart[index].Quantity <= 0)
            {
                OnGetDelete(id);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int staffId = _accountRepository.GetIdByUsername(Username);
            var request = new RequestBook();
            request.CreateDate = DateTime.Now;
            request.StaffId = staffId;
            var requestBookId = _requestBook.AddNewImportBook(request);
            for (int i = 0; i < cart.Count; i++)
            {
                _requestBookDetailRepository.AddNewRequestBookDetail(cart[i].Quantity, requestBookId, cart[i].Book.Id);
            }
            cart.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToPage("./Index");
        }
    }
}
