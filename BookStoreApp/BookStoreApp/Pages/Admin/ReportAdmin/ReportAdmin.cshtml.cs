using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Repository;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BookStoreApp.Pages.Admin.ReportAdmin
{
    public class ReportAdminModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookInStoreRepository _bookInStoreRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        public string Username { get; set; }
        public string Role { get; set; }
        public ReportAdminModel(IAccountRepository accountRepository, IBookInStoreRepository bookInStoreRepository, IStoreRepository storeRepository, IOrderRepository orderRepository, IBookRepository bookRepository)
        {
            _accountRepository = accountRepository;
            _bookInStoreRepository = bookInStoreRepository;
            _storeRepository = storeRepository;
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
        }

        public IList<BookInStore> BookInStore { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public int StoreId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public int NewOrder { get; set; }
        public decimal TotalOrderSale { get; set; }
        public int TotalOrder { get; set; }
        public int TotalBook { get; set; }
        public string cateTitle { get; set; }
        public string amountBookByCat { get; set; }
        public void OnGet()
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
 
            List<Order> orders = _orderRepository.GetOrders();
            TotalOrderSale = (decimal)orders.Sum(o => o.TotalPrice);
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.ToShortDateString();
            NewOrder = orders.Where(o => o.CreateDate.ToString().Contains(date)).Count();
            Console.WriteLine("Date: " + date);
            TotalOrder = orders.Count();
            TotalBook = (int)_bookRepository.GetBooks().Sum(o => o.Amount);

        }
    }
}
