using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAccountRepository
    {
        Account CheckLogin(string username, string password);
        Account Register(Account account);
        Account GetAccountByUsername(string username);
        List<Account> GetAccounts();
        Account GetAccountById(int id);
        void RemoveAccount(int id);
        void CreateNewAccount(Account account);
        void UpdateAccount(Account account);
        int GetIdByUsername(string username);
        bool CheckUserByUsername(string username);
    }
}
