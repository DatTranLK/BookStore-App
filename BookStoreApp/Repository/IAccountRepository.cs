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
        void Register(Account account);
        Account GetAccountByUsername(string username);
    }
}
