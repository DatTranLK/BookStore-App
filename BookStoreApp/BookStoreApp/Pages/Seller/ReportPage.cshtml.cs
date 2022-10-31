using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace BookStoreApp.Pages.Seller
{
    public class ReportPageModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBookInStoreRepository _bookInStoreRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IOrderRepository _orderRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public ReportPageModel(IAccountRepository accountRepository, IBookInStoreRepository bookInStoreRepository, IStoreRepository storeRepository, IOrderRepository orderRepository)
        {
            _accountRepository = accountRepository;
            _bookInStoreRepository = bookInStoreRepository;
            _storeRepository = storeRepository;
            _orderRepository = orderRepository;
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
            BookInStore = _bookInStoreRepository.GetBookInStores((int)Account.StoreId);
            if (BookInStore == null)
            {
                Msg = "There is no BookInStore in here";
            }
            List<Order> orders = _orderRepository.GetOrderByStaffID(Account.Id);
            TotalOrderSale = (decimal)orders.Sum(o => o.TotalPrice);
            var dateAndTime = DateTime.Now;
            var date = dateAndTime.ToShortDateString();
            NewOrder = orders.Where(o => o.CreateDate.ToString().Contains(date)).Count();
            Console.WriteLine("Date: " + date);
            TotalOrder = orders.Count();
            TotalBook = (int)_bookInStoreRepository.GetBookInStores((int)Account.StoreId).Sum(o => o.Amount);

            
            List<String> cate = new List<String>();
  
            foreach (var item in BookInStore)
            {
                
                if (!cate.Contains(item.Book.Category.Name))
                {
                    cate.Add(item.Book.Category.Name);   
                }
                
            }
            cate.Remove("");

            List<String> amount = BookInStore
            .GroupBy(l => l.Book.CategoryId)
            .Select(cl =>
            {
                String v = cl.Sum(c => c.Amount).ToString();
                return v;
            }).ToList();

           
            amountBookByCat = JsonConvert.SerializeObject(amount); 
            cateTitle = JsonConvert.SerializeObject(cate);
            Console.WriteLine(amountBookByCat.ToString());
            Console.WriteLine(cateTitle.ToString());
            foreach (var item in cateTitle)
            {
                Console.WriteLine("cate: " + item);
            }
            foreach (var item in amountBookByCat)
            {
                Console.WriteLine("amount: " + item);
            }
        }
    }
}
