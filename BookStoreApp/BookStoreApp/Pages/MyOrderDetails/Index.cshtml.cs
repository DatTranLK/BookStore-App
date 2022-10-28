using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;

namespace BookStoreApp.Pages.MyOrderDetails
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IBookRepository _bookRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public IndexModel(IAccountRepository accountRepository, IOrderDetailRepository orderDetailRepository, IStoreRepository storeRepository, IBookRepository bookRepository)
        {
            _accountRepository = accountRepository;
            _orderDetailRepository = orderDetailRepository;
            _storeRepository = storeRepository;
            _bookRepository = bookRepository;
        }
        public IList<OrderDetail> OrderDetail { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public void OnGet(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            OrderDetail = _orderDetailRepository.GetOrderDetailDAOsVerCustomer(id);

            if (OrderDetail == null)
            {
                Msg = "There is no order detail in here";
            }
        }
    }
}
