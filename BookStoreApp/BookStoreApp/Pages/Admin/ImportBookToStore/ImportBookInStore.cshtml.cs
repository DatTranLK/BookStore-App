using BookStoreApp.Helper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Admin.ImportBookToStore
{
    public class ImportBookInStoreModel : PageModel
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IRequestBookRepository _requestBook;
        private readonly IRequestBookDetailRepository _requestBookDetailRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IBookInStoreRepository _bookInStoreRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public int StoreId { get; set; }
        public List<Item> importCak { get; set; }
        public IList<Store> Store { get; set; }
        public string Msg { get; set; }

        public ImportBookInStoreModel(IBookRepository bookRepository, IAccountRepository accountRepository, IRequestBookRepository requestBook, IRequestBookDetailRepository requestBookDetailRepository, IStoreRepository storeRepository, IBookInStoreRepository bookInStoreRepository)
        {
            _bookRepository = bookRepository;
            _accountRepository = accountRepository;
            _requestBook = requestBook;
            _requestBookDetailRepository = requestBookDetailRepository;
            _storeRepository = storeRepository;
            _bookInStoreRepository = bookInStoreRepository;
        }
        public Account Account { get; set; }


        public void OnGet(int id, int storeId)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            StoreId = storeId;

            importCak = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "importCak");
            HttpContext.Session.SetString("CheckStore1", storeId.ToString());
            if (HttpContext.Session.GetString("CheckStore2") != HttpContext.Session.GetString("CheckStore1") && HttpContext.Session.GetString("CheckStore2") != null)
            {
                Msg = "You can only import 1 book to 1 store in each time";
            }
            else
            {
                var book = _bookRepository.GetBookById(id);

                if (importCak == null)
                {
                    importCak = new List<Item>();
                    importCak.Add(new Item
                    {
                        Book = book,
                        Quantity = 1
                    });
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "importCak", importCak);
                    HttpContext.Session.SetString("CheckStore2", storeId.ToString());

                }
                else
                {
                    int index = Exists(importCak, id);
                    if (index == -1)
                    {
                        importCak.Add(new Item
                        {
                            Book = book,
                            Quantity = 1
                        });
                    }
                    else
                    {
                        importCak[index].Quantity++;
                    }

                    SessionHelper.SetObjectAsJson(HttpContext.Session, "importCak", importCak);
                    HttpContext.Session.SetString("CheckStore2", storeId.ToString());
                }
            }
        }

        public void OnGetDelete(int id, int storeId)
        {
            if (HttpContext.Session.GetString("CheckStore2") != null)
            {
                Username = HttpContext.Session.GetString("Username");
                Role = HttpContext.Session.GetString("Role");
                Account = _accountRepository.GetAccountByUsername(Username);
                Store = _storeRepository.GetStoresNoDes();
                StoreId = int.Parse(HttpContext.Session.GetString("CheckStore2"));
                importCak = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "importCak");
                int index = Exists(importCak, id);
                importCak.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "importCak", importCak);
            }
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

        public void OnGetIncrease(int id, int storeId)
        {
            if (HttpContext.Session.GetString("CheckStore2") != null)
            {
                Username = HttpContext.Session.GetString("Username");
                Role = HttpContext.Session.GetString("Role");
                Account = _accountRepository.GetAccountByUsername(Username);
                Store = _storeRepository.GetStoresNoDes();
                StoreId = int.Parse(HttpContext.Session.GetString("CheckStore2"));
                importCak = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "importCak");
                int index = Exists(importCak, id);
                importCak[index].Quantity++;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "importCak", importCak);
            }

        }

        public void OnGetDecrease(int id, int storeId)
        {
            if (HttpContext.Session.GetString("CheckStore2") != null)
            {
                Username = HttpContext.Session.GetString("Username");
                Role = HttpContext.Session.GetString("Role");
                Account = _accountRepository.GetAccountByUsername(Username);
                Store = _storeRepository.GetStoresNoDes();
                StoreId = int.Parse(HttpContext.Session.GetString("CheckStore2")); ;
                importCak = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "importCak");
                int index = Exists(importCak, id);
                importCak[index].Quantity--;
                if (importCak[index].Quantity <= 0)
                {
                    OnGetDelete(id, storeId);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "importCak", importCak);
            }
        }
        public async Task<IActionResult> OnPostAsync(int id, int storeId)
        {
            if (HttpContext.Session.GetString("CheckStore2") != null)
            {
                Username = HttpContext.Session.GetString("Username");
                Role = HttpContext.Session.GetString("Role");
                Account = _accountRepository.GetAccountByUsername(Username);
                Store = _storeRepository.GetStoresNoDes();
                StoreId = int.Parse(HttpContext.Session.GetString("CheckStore2"));
                importCak = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "importCak");
                for (int i = 0; i < importCak.Count; i++)
                {
                    var res = _bookInStoreRepository.ImportBookToStore(importCak[i].Quantity, StoreId, importCak[i].Book.Id);
                    if (res == false)
                    {
                        Msg = "The amount of book in the warehouse is not enough to import to store";
                        return Page();
                    }
                }
                importCak.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "importCak", importCak);
                return RedirectToPage("/Admin/ImportBookToStore/Index", new { id = StoreId });
            }
            return Page();
        }
    }
}
