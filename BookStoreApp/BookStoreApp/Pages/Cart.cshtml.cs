using BookStoreApp.Helper;
using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public CartModel(IAccountRepository accountRepository, IBookRepository bookRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _accountRepository = accountRepository;
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }
        
        public string Username { get; set; }
        public string Role { get; set; }
        public List<Item> cartCus { get; set; }
        public Book Book { get; set; }
        public Account Account { get; set; }
        [BindProperty]
        public decimal? Total { get; set; } = 0;
        public string ShippingAddress { get; set; }


        public void OnGet(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            cartCus = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartCus");
            var book = _bookRepository.GetBookById(id);
            if (cartCus == null)
            {
                cartCus = new List<Item>();
                cartCus.Add(new Item
                {
                    Book = book,
                    Quantity = 1                   
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cartCus", cartCus);

            }
            else
            {
                int index = Exists(cartCus, id);
                if (index == -1)
                {
                    cartCus.Add(new Item
                    {
                        Book = book,
                        Quantity = 1
                    });
                }
                else
                {
                    cartCus[index].Quantity++;
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cartCus", cartCus);
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
            cartCus = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartCus");
            int index = Exists(cartCus, id);
            cartCus.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartCus", cartCus);
        }

        public void OnGetIncrease(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            cartCus = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartCus");
            int index = Exists(cartCus, id);
            cartCus[index].Quantity++;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartCus", cartCus);
        }

        public void OnGetDecrease(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            cartCus = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartCus");
            int index = Exists(cartCus, id);
            cartCus[index].Quantity--;
            if (cartCus[index].Quantity <= 0)
            {
                OnGetDelete(id);
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartCus", cartCus);
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
            var ShippingAddressString = Request.Form["SubShippingAddr"];

            cartCus = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cartCus");
            int customerId = _accountRepository.GetIdByUsername(Username);
            var order = new Order();
            order.CreateDate = DateTime.Now;
            order.CustomerId = customerId;
            order.StaffId = null;
            order.ShippingAddress = ShippingAddressString;           
            order.TotalPrice = total;
            int orderId = _orderRepository.CreateNewOrder(order);
            for (int i = 0; i < cartCus.Count; i++)
            {
                _orderDetailRepository.AddNewOrderDetail(cartCus[i].Quantity, orderId, cartCus[i].Book.Id);
            }
            cartCus.Clear();
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cartCus", cartCus);
            return RedirectToPage("./Index");
        }
    }
}
