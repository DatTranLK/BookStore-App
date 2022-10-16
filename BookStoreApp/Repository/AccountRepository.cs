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

        public void CreateNewAccount(Account account) => AccountDAO.Instance.CreateNewAccount(account);

        public Account GetAccountById(int id) => AccountDAO.Instance.GetAccountById(id);

        public Account GetAccountByUsername(string username) => AccountDAO.Instance.GetAccountByUsername(username);

        public List<Account> GetAccounts() => AccountDAO.Instance.GetAccounts();

        public void Register(Account account) => AccountDAO.Instance.Register(account);

        public void RemoveAccount(int id) => AccountDAO.Instance.RemoveAccount(id);

        public void UpdateAccount(Account account) => AccountDAO.Instance.UpdateAccount(account);
    }
}
