using BookStoreApp.Helper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Seller
{
    public class CartSellerModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IStoreRepository _storeRepository;

        public CartSellerModel(IAccountRepository accountRepository, IBookRepository bookRepository, 
            IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _storeRepository = storeRepository;
        }
        public string Username { get; set; }
        public string Role { get; set; }
        public List<Item> cartSeller { get; set; }
        public Book Book { get; set; }
        public Account Account { get; set; }
        public int StoreId { get; set; }
        public IList<Store> Store { get; set; }
        public string Msg { get; set; }
        [BindProperty]
        public decimal? Total { get; set; } = 0;
        public string CustomerName { get; set; }
        public void OnGet(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            cartSeller = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartSeller");
            Store = _storeRepository.GetStoresNoDes();
            var book = _bookRepository.GetBookById(id); 
            if (cartSeller == null)
            {
                cartSeller = new List<Item>();
                cartSeller.Add(new Item
                {
                    Book = book,
                    Quantity = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cartSeller", cartSeller);
            }
            else
            {
                int index = Exists(cartSeller, id);
                if (index == -1)
                {
                    cartSeller.Add(new Item
                    {
                        Book = book,
                        Quantity = 1
                    });
                }
                else
                {
                    cartSeller[index].Quantity++;
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cartSeller", cartSeller);
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

        public void OnGetDelete(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            cartSeller = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartSeller");
            HttpContext.Session.GetString("storeId");
            int index = Exists(cartSeller, id);
            cartSeller.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartSeller", cartSeller);
        }

        public void OnGetIncrease(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();

            cartSeller = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartSeller");
            int index = Exists(cartSeller, id);
            cartSeller[index].Quantity++;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartSeller", cartSeller);
        }

        public void OnGetDecrease(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();

            cartSeller = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartSeller");
            int index = Exists(cartSeller, id);
            cartSeller[index].Quantity--;
            if (cartSeller[index].Quantity <= 0)
            {
                OnGetDelete(id);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartSeller", cartSeller);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            var totalString = Request.Form["SubTotal"];
            decimal total;
            decimal? result = null;
            if (decimal.TryParse((string)totalString, out total))
                result = total;
            

            cartSeller = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartSeller");
            int staffId = _accountRepository.GetIdByUsername(Username);
            var order = new Order();
            order.CreateDate = DateTime.Now;
            var customerNameString = Request.Form["SubCustomerName"];
            if (!string.IsNullOrEmpty(customerNameString))
            {
                var acc = _accountRepository.GetAccountByUsername(customerNameString);
                if (acc != null)
                {                  
                    order.CustomerId = acc.Id;
                }
                else
                {
                    Msg = "This user does not exist!!";
                    return Page();
                }
            }
            else
            {
                order.CustomerId = null;
            }
            order.StaffId = (int)Account.Id;
            order.ShippingAddress = null;
            order.TotalPrice = total;
            order.OrderStatus = "Done";
            int orderId = _orderRepository.CreateNewOrder(order);
            for (int i = 0; i < cartSeller.Count; i++)
            {
                _orderDetailRepository.AddNewOrderDetailForSeller(cartSeller[i].Quantity, orderId, (int)Account.StoreId, cartSeller[i].Book.Id);
            }
            cartSeller.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartSeller", cartSeller);
            return RedirectToPage("./BookView");
        }
    }
}
