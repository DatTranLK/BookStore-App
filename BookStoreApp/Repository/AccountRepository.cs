using BusinessObject.Models;
using DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Account CheckLogin(string username, string password) => AccountDAO.Instance.CheckLogin(username, password);

        public Account GetAccountByUsername(string username) => AccountDAO.Instance.GetAccountByUsername(username);

        public void Register(Account account) => AccountDAO.Instance.Register(account);
    }
}
