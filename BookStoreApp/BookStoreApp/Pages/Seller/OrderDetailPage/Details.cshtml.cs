using BusinessObject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApp.Pages.Seller.OrderDetailPage
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IStoreRepository _storeRepository;

        public string Username { get; set; }
        public string Role { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public IList<Store> Store { get; set; }
        public Account Account { get; set; }
        public string Msg { get; set; }
        public DetailsModel(IAccountRepository accountRepository, IOrderDetailRepository orderDetailRepository, IStoreRepository storeRepository)
        {
            _accountRepository = accountRepository;
            _orderDetailRepository = orderDetailRepository;
            _storeRepository = storeRepository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Username = HttpContext.Session.GetString("Username");
            Role = HttpContext.Session.GetString("Role");
            Account = _accountRepository.GetAccountByUsername(Username);
            Store = _storeRepository.GetStoresNoDes();
            if (id == null)
            {
                Msg = "The id is null";
            }

            OrderDetail = _orderDetailRepository.GetOrderDetailById(id);

            if (OrderDetail == null)
            {
                Msg = "Does not see the order detail";
            }
            return Page();
        }
    }
}
